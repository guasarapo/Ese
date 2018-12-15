/*
 * Creado por SharpDevelop.
 * Usuario: Carlos Marichal
 * Fecha: 24/07/2018
 * Hora: 01:06 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Ese
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnEnviar;
		private System.Windows.Forms.TextBox txtMensaje;
		private System.Windows.Forms.ListBox lstUsuarios;
		private System.Windows.Forms.TextBox txtChat;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnEnviar = new System.Windows.Forms.Button();
			this.txtMensaje = new System.Windows.Forms.TextBox();
			this.lstUsuarios = new System.Windows.Forms.ListBox();
			this.txtChat = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblUsuariosSelec = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnEnviar
			// 
			this.btnEnviar.Location = new System.Drawing.Point(335, 326);
			this.btnEnviar.Name = "btnEnviar";
			this.btnEnviar.Size = new System.Drawing.Size(75, 23);
			this.btnEnviar.TabIndex = 0;
			this.btnEnviar.Text = "Enviar";
			this.btnEnviar.UseVisualStyleBackColor = true;
			this.btnEnviar.Click += new System.EventHandler(this.BtnEnviarClick);
			// 
			// txtMensaje
			// 
			this.txtMensaje.Location = new System.Drawing.Point(12, 328);
			this.txtMensaje.Name = "txtMensaje";
			this.txtMensaje.Size = new System.Drawing.Size(308, 20);
			this.txtMensaje.TabIndex = 1;
			// 
			// lstUsuarios
			// 
			this.lstUsuarios.FormattingEnabled = true;
			this.lstUsuarios.Location = new System.Drawing.Point(12, 49);
			this.lstUsuarios.Name = "lstUsuarios";
			this.lstUsuarios.Size = new System.Drawing.Size(120, 264);
			this.lstUsuarios.TabIndex = 2;
			this.lstUsuarios.SelectedIndexChanged += new System.EventHandler(this.lstUsuarios_SelectedIndexChanged);
			// 
			// txtChat
			// 
			this.txtChat.BackColor = System.Drawing.SystemColors.Window;
			this.txtChat.Location = new System.Drawing.Point(138, 49);
			this.txtChat.Multiline = true;
			this.txtChat.Name = "txtChat";
			this.txtChat.ReadOnly = true;
			this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChat.Size = new System.Drawing.Size(290, 264);
			this.txtChat.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(138, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Mensaje Para:";
			// 
			// lblUsuariosSelec
			// 
			this.lblUsuariosSelec.AutoSize = true;
			this.lblUsuariosSelec.Location = new System.Drawing.Point(216, 25);
			this.lblUsuariosSelec.Name = "lblUsuariosSelec";
			this.lblUsuariosSelec.Size = new System.Drawing.Size(0, 13);
			this.lblUsuariosSelec.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Usuarios Conectados";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 361);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblUsuariosSelec);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtChat);
			this.Controls.Add(this.lstUsuarios);
			this.Controls.Add(this.txtMensaje);
			this.Controls.Add(this.btnEnviar);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Ese... Chat UDP";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuariosSelec;
        private System.Windows.Forms.Label label2;
	}
}
