using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PracticaFinal
{
    public partial class Agregar : Form
    {
        public string title { get; set; }
        public string author { get; set; }
        public int pages { get; set; }
        public int year { get; set; }
        public string idiom { get; set; }
        public string portada { get; set; }
        public string contenido { get; set; }

        public Agregar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.IsBalloon = true;
            if (titulo.Text == null || titulo.Text.Trim() == "")
            {
                tp.SetToolTip(titulo, "Campo obligatorio");
                tp.Show("Obligatorio", titulo);

            }
            else
            {
                title = titulo.Text;
                author = autor.Text;
                pages = (int)paginas.Value;
                year = (int)anyo.Value;
                idiom = idioma.Text;
                //portada se elegiría con browse_click()
                DialogResult = DialogResult.OK;
            }
            
        }

        private void browse_Click(object sender, EventArgs e)
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

                        Bitmap portado = new Bitmap(myOpenFileDialog.FileName);
                        string rName = (myOpenFileDialog.FileName).ToString();
                        
                        string[] fuck = rName.Split('\\');
                        string imgName = fuck[fuck.Length-1];
  
                        using (MemoryStream stream = new MemoryStream())
                        {
                            
                            portado.Save(stream, ImageFormat.Jpeg);

                            FileStream file = new FileStream(@"..\..\Resources\"+
                                        imgName, FileMode.Create, FileAccess.Write);
                            
                            stream.WriteTo(file);
                            file.Close();


                            portada = @"..\..\Resources\" + imgName;
                            
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Porfavor suba una imagen.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Buscaré y copiaré el archivo pdf elegido, y se lo asignaré al objeto libro:
        private void browsePdf_Click(object sender, EventArgs e)
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

                        String docPath2 = @"..\..\Resources\"+ docName;

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
    }
}
