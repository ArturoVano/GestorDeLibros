using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaFinal
{
    public partial class Modificaciones : Form
    {
        List<Libro> Libros { get; set; }
        public int cursor { get; set; } = 0;
        List<Autor> Autores { get; set; }

        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int pages { get; set; }
        public int year { get; set; }
        public string idiom { get; set; }
        public string portada { get; set; }
        public string contenido { get; set; }

        public Modificaciones()
        {
            InitializeComponent();
        }

        public Modificaciones(List<Libro> ls, List<Autor> a)
        {
            InitializeComponent();

            Libros = ls;
            Autores = a;
            showData();


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void btnNext_Click(object sender, EventArgs e)
        {
 
            if (cursor < Libros.Count-1)
            {
                cursor++;
            }
            else
            {
                cursor = 0;
            }
            lId.Text = (Libros[cursor].libro_id).ToString();
            lTit.Text = Libros[cursor].titulo;

            showData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (cursor > 0)
            {
                cursor--;
            }
            else
            {
                cursor = Libros.Count - 1;
            }
            showData();
        }

        // MÉTODO para mostrar info del libro actual al usuario:
        private void showData()
        {
            id = Libros[cursor].libro_id;
            lId.Text = id.ToString();
            
            lTit.Text = Libros[cursor].titulo;
            tbTit.Text = Libros[cursor].titulo;

            try {
                Autor a = Autores.First(r => r.autor_id == Libros[cursor].autor_id);
                if (a != null) {

                    lAut.Text = a.nombre;
                    tbAut.Text = a.nombre;
                } else
                    lAut.Text = "'Desconocido'";
            } catch (System.InvalidOperationException) {

                lAut.Text = "'Desconocido'";
            }
             
            lYea.Text = (Libros[cursor].anyo).ToString();
            tbYea.Text = (Libros[cursor].anyo).ToString();

            lIdi.Text = Libros[cursor].idioma;
            idioma.Text = Libros[cursor].idioma;

            lPag.Text = (Libros[cursor].paginas).ToString();
            pag.Text = (Libros[cursor].paginas).ToString();

            portada = Libros[cursor].portada;
            if ( portada != null && portada != "")
            {
                try
                {
                    Bitmap img = new Bitmap(Libros[cursor].portada); 
                    pictureBox1.Image = (Image)(new Bitmap(img, new Size(151, 167)));
                }
                catch (System.ArgumentException)
                {
                    pictureBox1.Image = (Image)(new Bitmap(Properties.Resources.BOOK, new Size(151, 167)));
                }
            }
            else
            {
                pictureBox1.Image = Properties.Resources.BOOK;
            }
                
            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            ToolTip tp = new ToolTip();
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.IsBalloon = true;

            if (tbTit.Text == null || tbTit.Text == "")
            {
                
                tp.SetToolTip(tbTit, "Campo obligatorio");
                tp.Show("Obligatorio", tbTit);

            }
            else
            {
                title = tbTit.Text;
                author = tbAut.Text;
                pages = (int)pag.Value;
                year = (int)tbYea.Value;
                idiom = idioma.Text;
                //MessageBox.Show("Libro: "+ title + " con ID: " + id+ " Se ha modificado con éxito", "Confirmación");
                DialogResult = DialogResult.OK;
            }
        }

        private void browseImg_Click(object sender, EventArgs e)
        {
            //Empiezo diciendole al openFileDialog que se abra en el escritorio del usuario:
            myOpenFileDialog.InitialDirectory = "C://Desktop";

            // Nombre del título del cuadro de diálogo abierto:
            myOpenFileDialog.Title = "Seleccione la imagen para portada.";

            // Filtro del tipo de formato de imagen podemos cargar en la base de dato:
            myOpenFileDialog.Filter = "Image Only (*. jpg; * .jpeg; * .gif; * .bmp; * .png) | * .jpg; * .jpeg; * .gif; * .bmp; * .png";

            //FilterIndex representa el índice del filtro seleccionado en el fileDialog:
            myOpenFileDialog.FilterIndex = 1;

            try
            {
                if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (myOpenFileDialog.CheckFileExists)
                    {

                        Bitmap miPortada = new Bitmap(myOpenFileDialog.FileName);
                        string rName = (myOpenFileDialog.FileName).ToString();

                        string[] fuck = rName.Split('\\');
                        string imgName = fuck[fuck.Length - 1];

                        using (MemoryStream stream = new MemoryStream())
                        {

                            miPortada.Save(stream, ImageFormat.Jpeg);

                            FileStream file = new FileStream(@"..\..\Resources\" +
                                        imgName, FileMode.Create, FileAccess.Write);

                            stream.WriteTo(file);
                            file.Close();

                            portada = @"..\..\Resources\" + imgName;

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor suba una imagen.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error tipo: "+ ex.GetType().Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myOpenFileDialog.InitialDirectory = "C://Desktop";
            myOpenFileDialog.Title = "Seleccione el pdf contenido del libro.";
            myOpenFileDialog.Filter = "Pdf Files|*.pdf";
            myOpenFileDialog.FilterIndex = 1;

            try
            {
                if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (myOpenFileDialog.CheckFileExists)
                    {
                        //Cojo la ruta relativa del pdf elegido:
                        String docPath = (myOpenFileDialog.FileName).ToString();
                        //Me quedo solo con el nombre del pdf, la útlima parte:
                        string[] fuck = docPath.Split('\\');
                        string docName = fuck[fuck.Length - 1];

                        String docPath2 = @"..\..\Resources\" + docName;

                        //Me aseguro que la ruta destino no exista ya:
                        if (File.Exists(docPath2))
                            File.Delete(docPath2);

                        File.Copy(docPath, docPath2);

                        //Miro si mi copia existe:
                        if (!File.Exists(docPath2))
                            MessageBox.Show("A ocurrido un error insperado al guardar el archivo.");

                        else
                            contenido = @"..\..\Resources\" + docName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ilMax_Click(object sender, EventArgs e) {

            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void ilMin_Click(object sender, EventArgs e) {

            this.WindowState = FormWindowState.Minimized;
        }
    }
}
