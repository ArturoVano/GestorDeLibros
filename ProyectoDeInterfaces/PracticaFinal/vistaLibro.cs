using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaFinal
{
    public partial class vistaLibro: UserControl
    {

        public int info_id { get; set; }
        public string info_titulo { get; set; }
        public int info_anyo { get; set; }
        public string info_autor { get; set; }
        public string info_portada { get; set; }
        public string info_contenido { get; set; }

        public DialogResult DialogResult { get; private set; }

        public event EventHandler ManejadorClickEnBoton;


        public vistaLibro()
        {
            InitializeComponent();
        }


        public void setText(string txt)
        {
            label1.Text = txt;
        }
        public void cambiaColorEct(System.Drawing.Color c)
        {
            label1.ForeColor = c;
        }
        public void setBtnImage(Image img)
        {
            if (img != null)
                libPortada.Image = (Image)(new Bitmap(img, new Size(113, 132)));
        }
        

        private void button1_Click(object sender, EventArgs e) {

            //Se llama al manejador al hacer click en el botón
            ManejadorClickEnBoton?.Invoke(this, e);
            
        }

        
       
    }
}
