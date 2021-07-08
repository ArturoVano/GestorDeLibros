namespace PracticaFinal {
    partial class infoLibros {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnPortada = new System.Windows.Forms.Button();
            this.titulo = new System.Windows.Forms.Label();
            this.autor = new System.Windows.Forms.Label();
            this.anyo = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.ilMin = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPortada
            // 
            this.btnPortada.Location = new System.Drawing.Point(48, 100);
            this.btnPortada.Name = "btnPortada";
            this.btnPortada.Size = new System.Drawing.Size(174, 236);
            this.btnPortada.TabIndex = 0;
            this.btnPortada.UseVisualStyleBackColor = true;
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titulo.Location = new System.Drawing.Point(260, 100);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(54, 19);
            this.titulo.TabIndex = 1;
            this.titulo.Text = "label1";
            // 
            // autor
            // 
            this.autor.AutoSize = true;
            this.autor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.autor.Location = new System.Drawing.Point(297, 149);
            this.autor.Name = "autor";
            this.autor.Size = new System.Drawing.Size(56, 18);
            this.autor.TabIndex = 2;
            this.autor.Text = "autor - ";
            // 
            // anyo
            // 
            this.anyo.AutoSize = true;
            this.anyo.Font = new System.Drawing.Font("Arial", 12F);
            this.anyo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.anyo.Location = new System.Drawing.Point(297, 208);
            this.anyo.Name = "anyo";
            this.anyo.Size = new System.Drawing.Size(47, 18);
            this.anyo.TabIndex = 3;
            this.anyo.Text = "año - ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.button2.Location = new System.Drawing.Point(283, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 45);
            this.button2.TabIndex = 24;
            this.button2.Text = "Abrir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.delBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.delBtn.Location = new System.Drawing.Point(471, 291);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(115, 45);
            this.delBtn.TabIndex = 25;
            this.delBtn.Text = "Eliminar";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel6.Controls.Add(this.btnClose);
            this.panel6.Controls.Add(this.ilMin);
            this.panel6.Location = new System.Drawing.Point(-2, -4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(646, 43);
            this.panel6.TabIndex = 26;
            this.panel6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel6_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::PracticaFinal.Properties.Resources.icons8_close_window_26;
            this.btnClose.Location = new System.Drawing.Point(613, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ilMin
            // 
            this.ilMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ilMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ilMin.Image = global::PracticaFinal.Properties.Resources.icons8_minimize_window_26;
            this.ilMin.Location = new System.Drawing.Point(531, 6);
            this.ilMin.Name = "ilMin";
            this.ilMin.Size = new System.Drawing.Size(37, 36);
            this.ilMin.TabIndex = 1;
            this.ilMin.UseVisualStyleBackColor = true;
            this.ilMin.Click += new System.EventHandler(this.ilMin_Click);
            // 
            // infoLibros
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(643, 393);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.anyo);
            this.Controls.Add(this.autor);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.btnPortada);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "infoLibros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "infoLibros";
            this.TopMost = true;
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPortada;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Label autor;
        private System.Windows.Forms.Label anyo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button ilMin;
        private System.Windows.Forms.Button btnClose;
    }
}