/*
 * Creado por SharpDevelop.
 * Usuario: Carlos Marichal
 * Fecha: 31/07/2018
 * Hora: 07:38 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ese
{
	/// <summary>
	/// Description of FrmLogin.
	/// </summary>
	public partial class FrmLogin : Form
	{
		string nombreUsuario = "";
		
		public string NombreUsuario
		{
			get
			{
				return nombreUsuario;
			}
		}
		
		public FrmLogin()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			txtUsuario.Focus();
		}
		
		void BntCancelarClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void BtnAceptarClick(object sender, EventArgs e)
		{
			nombreUsuario = txtUsuario.Text.Trim();
			
			if(string.IsNullOrEmpty(nombreUsuario))
			{
				MessageBox.Show("Debe colocar un nombre de usuario para iniciar sesion", "UDP Chat", 
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtUsuario.Focus();
				return;
			}
			this.Close();
			
		}
		
		void FrmLoginFormClosing(object sender, FormClosingEventArgs e)
		{
			txtUsuario.Clear();
		}
		
		void FrmLoginLoad(object sender, EventArgs e)
		{
			
		}
	}
}
