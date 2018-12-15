/*
 * Creado por SharpDevelop.
 * Usuario: Carlos Marichal
 * Fecha: 31/07/2018
 * Hora: 07:38 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Ese
{
	partial class FrmLogin
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.Button bntCancelar;
		
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
			this.btnAceptar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.bntCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnAceptar
			// 
			this.btnAceptar.Location = new System.Drawing.Point(83, 59);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 23);
			this.btnAceptar.TabIndex = 1;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			this.btnAceptar.Click += new System.EventHandler(this.BtnAceptarClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Usuario:";
			// 
			// txtUsuario
			// 
			this.txtUsuario.Location = new System.Drawing.Point(66, 23);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(173, 20);
			this.txtUsuario.TabIndex = 0;
			// 
			// bntCancelar
			// 
			this.bntCancelar.Location = new System.Drawing.Point(164, 59);
			this.bntCancelar.Name = "bntCancelar";
			this.bntCancelar.Size = new System.Drawing.Size(75, 23);
			this.bntCancelar.TabIndex = 2;
			this.bntCancelar.Text = "Cancelar";
			this.bntCancelar.UseVisualStyleBackColor = true;
			this.bntCancelar.Click += new System.EventHandler(this.BntCancelarClick);
			// 
			// FrmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(256, 94);
			this.Controls.Add(this.bntCancelar);
			this.Controls.Add(this.txtUsuario);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAceptar);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmLogin";
			this.Text = "Inicio de Sesion";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLoginFormClosing);
			this.Load += new System.EventHandler(this.FrmLoginLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
