namespace Laberinto
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_mapa = new System.Windows.Forms.TextBox();
            this.txt_turnos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_mapa
            // 
            this.txt_mapa.Location = new System.Drawing.Point(12, 12);
            this.txt_mapa.Multiline = true;
            this.txt_mapa.Name = "txt_mapa";
            this.txt_mapa.Size = new System.Drawing.Size(463, 529);
            this.txt_mapa.TabIndex = 0;
            this.txt_mapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_mapa.TextChanged += new System.EventHandler(this.txt_mapa_TextChanged);
            // 
            // txt_turnos
            // 
            this.txt_turnos.Location = new System.Drawing.Point(194, 547);
            this.txt_turnos.Name = "txt_turnos";
            this.txt_turnos.Size = new System.Drawing.Size(100, 20);
            this.txt_turnos.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 576);
            this.Controls.Add(this.txt_turnos);
            this.Controls.Add(this.txt_mapa);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_mapa;
        private System.Windows.Forms.TextBox txt_turnos;
    }
}

