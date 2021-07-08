namespace PracticaFinal
{
    partial class Lector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lector));

            this.panel6 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            //((System.ComponentModel.ISupportInitialize)(this.lectorPDF)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lectorPDF
            // 
            /*this.lectorPDF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lectorPDF.Enabled = true;
            this.lectorPDF.Location = new System.Drawing.Point(2, 43);
            this.lectorPDF.Name = "lectorPDF";
            this.lectorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("lectorPDF.OcxState")));
            this.lectorPDF.Size = new System.Drawing.Size(799, 409);
            this.lectorPDF.TabIndex = 0;*/
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel6.Controls.Add(this.btnClose);
            this.panel6.Controls.Add(this.button5);
            this.panel6.Controls.Add(this.button4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(800, 43);
            this.panel6.TabIndex = 27;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::PracticaFinal.Properties.Resources.icons8_close_window_26;
            this.btnClose.Location = new System.Drawing.Point(700, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Right;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.button5.Image = global::PracticaFinal.Properties.Resources.icons8_maximize_window_26;
            this.button5.Location = new System.Drawing.Point(730, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 43);
            this.button5.TabIndex = 2;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.button4.Image = global::PracticaFinal.Properties.Resources.icons8_minimize_window_26;
            this.button4.Location = new System.Drawing.Point(763, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 43);
            this.button4.TabIndex = 1;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Lector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel6);
            //this.Controls.Add(this.lectorPDF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lector";
            //((System.ComponentModel.ISupportInitialize)(this.lectorPDF)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private AxAcroPDFLib.AxAcroPDF lectorPDF;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
    }
}