using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaFinal {
    public partial class infoLibros : Form {

        public int lib_id { get; set; }
        public string lib_titulo { get; set; }
        public string lib_autor { get; set; }
        public int lib_anyo { get; set; }
        public string lib_portada { get; set; }
        public string lib_contenido { get; set; }

        public infoLibros(string t, string a, int y, string p, string c) {
            InitializeComponent();
            //Damos valores a las variables locales
            lib_titulo = t;
            lib_autor = a;
            lib_anyo = y;
            lib_portada = p;
            lib_contenido = c;
            // ponemos la info. correspondiente en los label del Form:
            titulo.Text = t;
            autor.Text = a;
            anyo.Text = y.ToString();
            if (p != null && p != "")
            {  
                Image img = Image.FromFile(p);
                btnPortada.Image = (new Bitmap(img, new Size(174, 236)));
            }
            
            

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        //Pulsamos el botón de eliminar el Libro
        private void delBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            
        }

        

        //Boton para cerrar este formulario
        private void btnClose_Click(object sender, EventArgs e) {


            DialogResult = DialogResult.Abort;
            
        }

        private void openBtn_Click(object sender, EventArgs e) {

            try
            {
                if (lib_contenido != null)
                    System.Diagnostics.Process.Start(@lib_contenido);
                else
                    MessageBox.Show("Este libro no tiene asociado contenido", "Advertencia");
            }   
            catch(Exception ex)
            {
                MessageBox.Show("Error al abrir el libro. ");
            }

        }

        private void ilMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            

        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
