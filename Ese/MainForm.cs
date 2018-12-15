/*
 * Creado por SharpDevelop.
 * Usuario: Carlos Marichal
 * Fecha: 24/07/2018
 * Hora: 01:06 p.m.
 * 
 * Ese es un chat usando udp socket
 * version 0.1
 */
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;


namespace Ese
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		UdpClient receptor;					// socket udp
		string hostname;                    // nombre del equipo local
		string usuario;						// nombre del usuario
		
		byte[] datos = new byte[1024];      // buffer de datos enviado / recibidos
		
		struct UsuariosInfo                 // estructura de el usuario conectado
		{
			public IPEndPoint ipendpoint;
			public string Nombre;
		}
		
		ArrayList UsuariosList;             // lista de usuarios conectados   
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			receptor = new UdpClient(9050);	            // crea el cliente udp
			hostname = Dns.GetHostName();               // registra el nombre del equipo local
            receptor.BeginReceive(OnReceive, receptor); // empieza a recibir paquetes
			UsuariosList = new ArrayList();             // crea la lista de usuarios
		}
		
		/// <summary>
		/// llamado cuando se recibe un paquete udp
		/// </summary>
		/// <param name="ar"> Direccion y puero de donde se recibio el paquete
		/// </param>
		void OnReceive(IAsyncResult ar)
		{
			UdpClient cliente = (UdpClient)ar.AsyncState;             // se recibio un paquete
			IPEndPoint ipeEnviado = new IPEndPoint(IPAddress.Any, 0); // direccion y puerto de donde se recibio el pauete
			byte[] mensaje = cliente.EndReceive(ar, ref ipeEnviado);  // datos recibidos
  			Mensaje msg = new Mensaje(mensaje);                       // convierte el paquete de datos
  			
  			switch(msg.comando)
  			{
  				case Comando.login: 					// registra un usuario nuevo				
                    if(UsuariosList.Count == 0)
                    {
                        if (msg.origen != usuario)
                        {
                            UsuariosInfo _usuario = new UsuariosInfo();
                            _usuario.ipendpoint = ipeEnviado;
                            _usuario.Nombre = msg.origen;
                            UsuariosList.Add(_usuario);
                            lstUsuarios.Items.Add(_usuario.Nombre);
                            txtChat.Text += msg.origen + " Se a unido al chat" + Environment.NewLine;
                        }
                    }
                    else
                    {
                        bool Si_esta = false;
                        foreach (UsuariosInfo Usuarios in UsuariosList)
                        {            	
                        	if(Usuarios.Nombre == msg.origen || usuario == msg.origen) 
                        	{
								Si_esta = true;
							}
                        }
                        if (!Si_esta)
                        {
                            UsuariosInfo _usuario = new UsuariosInfo();
                            _usuario.ipendpoint = ipeEnviado;
                            _usuario.Nombre = msg.origen;
                            UsuariosList.Add(_usuario);
                            lstUsuarios.Items.Add(_usuario.Nombre);
                            txtChat.Text += msg.origen + " Se a unido al chat" + Environment.NewLine;
                        }
                    }
  					break;
  					
  				case Comando.logout:						// quita un usuario que dejo el chat
  					int indice = 0;
  					foreach(UsuariosInfo usuarios in UsuariosList)
  					{
                        if (usuarios.Nombre == msg.origen)
  						{
  							UsuariosList.RemoveAt(indice);
  							lstUsuarios.Items.Remove(usuarios.Nombre);
                            lstUsuarios.Refresh();
  							break;
  						}
  						++indice;
  					}
  					
  					txtChat.Text += msg.origen + " Se a desconectado del chat"+ Environment.NewLine;
  					break;
  					
  				case Comando.mensaje:			//entrega el mensaje al usuario
  					txtChat.Text += msg.origen + " Dice: " + Environment.NewLine;
  					txtChat.Text += "\t" + msg.mensaje + Environment.NewLine;
  					
  					txtChat.SelectionStart = txtChat.Text.Length;
					txtChat.ScrollToCaret();
					txtChat.Refresh();
  					break;	
  			}
  			
  			receptor.BeginReceive(OnReceive, ar.AsyncState);  //empieza a escuchar mensajes otra vez
		}
		
		/// <summary>
		/// Metodo de inicio al cargar el formulario
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MainFormLoad(object sender, EventArgs e)
		{
			CheckForIllegalCrossThreadCalls = false;
			
			this.Hide();
			
			using(FrmLogin login = new FrmLogin()) // muestra el formulario de login
			{
				login.ShowDialog();
				
				if(login.NombreUsuario == "")
					this.Close();
				else
				{
					usuario = login.NombreUsuario;
					this.Show();
				}	
			}
			txtMensaje.Focus();
			
			Thread divulgar = new Thread(new ThreadStart(DivulgarUsuario));
   			divulgar.IsBackground = true;
  		    divulgar.Start();

		}
		
		/// <summary>
		/// Metodo para enviar un mensaje
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnEnviarClick(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(UsuarioSeleccionado()))
			{
				MessageBox.Show("Debe seleccionar un usuario a quien enviar el mensaje", "UDP chat", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                lstUsuarios.Focus();
                return;
			}
			Mensaje msg = new Mensaje();
			msg.comando = Comando.mensaje;
			msg.origen = usuario;
			msg.destino = UsuarioSeleccionado();
			msg.mensaje = txtMensaje.Text;
			byte[] data = msg.GetBytes();
			IPEndPoint ipeDestino = null;
			
			foreach(UsuariosInfo usr in UsuariosList)
			{
				if(msg.destino == usr.Nombre)
				{
					ipeDestino = usr.ipendpoint;
				}
			}
			
			receptor.Send(data, data.Length, ipeDestino);
			
			txtChat.Text += msg.origen + " Dice: " + Environment.NewLine;
  			txtChat.Text += "\t" + msg.mensaje + Environment.NewLine;		
  			txtChat.SelectionStart = txtChat.Text.Length;
			txtChat.ScrollToCaret();
			txtChat.Refresh();
			
			txtMensaje.Clear();
        }
		
		/// <summary>
		/// Metodo para verificar si un usuario de la lista a sido seleccionado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedIndex == -1)
            {
                lblUsuariosSelec.Text = "Nadie";
            }
            else
            {
                lblUsuariosSelec.Text = lstUsuarios.SelectedItem.ToString();
            }
        }
        
        /// <summary>
        /// Envia un mensaje a todos los equipos de la red local
        /// </summary>
        private void DivulgarUsuario()
        {      
            IPEndPoint DivIpe = new IPEndPoint(IPAddress.Parse("192.168.0.255"), 9050);

            Mensaje msg = new Mensaje();
			msg.comando = Comando.login;
			msg.origen = usuario;
			msg.destino = "todos";
			msg.mensaje = "presentacion";
			byte[] data = msg.GetBytes();
			
			int contador = 0;
		
			while(contador < 30)
			{
				receptor.Send(data, data.Length, DivIpe);
				Thread.Sleep(30000);
			}
        }
        
        /// <summary>
        /// Entrega el nombre del usuario seleccionado en la lista de usuarios
        /// </summary>
        /// <returns></returns>
        private string UsuarioSeleccionado()
        {
            string destino = string.Empty;

            if(lstUsuarios.SelectedItems.Count < 1)
            {
                return destino;
            }
            
            destino = lstUsuarios.SelectedItem.ToString();
 
            return destino;
        }
		
        /// <summary>
        /// Metodo que se ejecuta al finalizar el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{                                                       
            IPEndPoint SalirIpe = new IPEndPoint(IPAddress.Parse("192.168.0.255"), 9050);
        	Mensaje msg = new Mensaje();                          
			msg.comando = Comando.logout;
			msg.origen = usuario;
			msg.destino = "";
			msg.mensaje = "";
			byte[] data = msg.GetBytes();
			
			receptor.Send(data, data.Length, SalirIpe);
			receptor.Close();
		} 
	}
	
	
}
