namespace jocDeTable
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelZaruri = new System.Windows.Forms.Panel();
            this.buttonZaruri = new System.Windows.Forms.Button();
            this.buttonSchimbaJucator = new System.Windows.Forms.Button();
            this.Tabla = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelZaruri
            // 
            this.panelZaruri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelZaruri.Location = new System.Drawing.Point(1063, 374);
            this.panelZaruri.Name = "panelZaruri";
            this.panelZaruri.Size = new System.Drawing.Size(300, 300);
            this.panelZaruri.TabIndex = 1;
            this.panelZaruri.Paint += new System.Windows.Forms.PaintEventHandler(this.panelZaruri_Paint);
            // 
            // buttonZaruri
            // 
            this.buttonZaruri.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonZaruri.Location = new System.Drawing.Point(1161, 194);
            this.buttonZaruri.Name = "buttonZaruri";
            this.buttonZaruri.Size = new System.Drawing.Size(100, 100);
            this.buttonZaruri.TabIndex = 2;
            this.buttonZaruri.Text = "Arunca";
            this.buttonZaruri.UseVisualStyleBackColor = true;
            this.buttonZaruri.Click += new System.EventHandler(this.buttonZaruri_Click);
            // 
            // buttonSchimbaJucator
            // 
            this.buttonSchimbaJucator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSchimbaJucator.Location = new System.Drawing.Point(1161, 74);
            this.buttonSchimbaJucator.Name = "buttonSchimbaJucator";
            this.buttonSchimbaJucator.Size = new System.Drawing.Size(100, 100);
            this.buttonSchimbaJucator.TabIndex = 3;
            this.buttonSchimbaJucator.Text = "Schimba Jucatorul";
            this.buttonSchimbaJucator.UseVisualStyleBackColor = true;
            this.buttonSchimbaJucator.Click += new System.EventHandler(this.buttonSchimbaJucator_Click);
            // 
            // Tabla
            // 
            this.Tabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabla.BackColor = System.Drawing.SystemColors.Control;
            this.Tabla.Location = new System.Drawing.Point(0, 0);
            this.Tabla.Name = "Tabla";
            this.Tabla.Size = new System.Drawing.Size(1050, 750);
            this.Tabla.TabIndex = 0;
            this.Tabla.Paint += new System.Windows.Forms.PaintEventHandler(this.Tabla_Paint);
            this.Tabla.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tabla_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 782);
            this.Controls.Add(this.buttonSchimbaJucator);
            this.Controls.Add(this.buttonZaruri);
            this.Controls.Add(this.panelZaruri);
            this.Controls.Add(this.Tabla);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Tabla;
        private System.Windows.Forms.Panel panelZaruri;
        private System.Windows.Forms.Button buttonZaruri;
        private System.Windows.Forms.Button buttonSchimbaJucator;
    }
}

