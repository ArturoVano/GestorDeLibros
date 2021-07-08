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

namespace PracticaFinal
{
    public partial class App : Form
    {
        modelo m;
        List<Libro> libros;
        List<Autor> autores;
        int numLibros;
        int ultimoIdLibro;
        int ultimoIdAutor;

        public App()
        {

            //Si falla la conexión, se le pregurará al usuario de reconectar hasta que diga que no:
            bool repetirCon = false;
            do
            {
                try
                {
                    m = new modelo();
                    repetirCon = false; //Todo ha ido bien, este bloque no se repetirá.
                }
                catch (MySql.Data.MySqlClient.MySqlException e) 
                {
                    
                    DialogResult dialogResult = MessageBox.Show("Error al conectar con el host, Tiempo agotado, ¿Quiere intentar recontectar?", "Error de tipo: " + e.GetType().Name,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dialogResult == DialogResult.No)
                    {
                        Environment.Exit(1); //Terminar el proceso.
                    }
                    else if (dialogResult == DialogResult.Yes)
                        repetirCon = true; //Volverá a intentar la conexión
                }
            } while (repetirCon == true);

            InitializeComponent();

            //Quitar el borde del Form:
            this.Text = string.Empty;
            this.ControlBox = false;
            //Indicar los limites del máximizado al área de trabajo del escritorio:
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            libros = m.getLibros();
            ultimoIdLibro = m.getLastLibroId();
            //Para saber de cuantos libros disponemos y, por tanto, de cuantas columnas y filas tendremos:
            numLibros = libros.Count;
            muestraLibros();

            autores = m.getAutores();
            ultimoIdAutor = m.getLastAutorId();

            //No se ha implementado:
            label1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            if (numLibros == 0) //Todavía no hay ningún libro
            { //Pongo uno básico de ejemplo:
                libros.Add(new Libro(0, 0, 0, "Ejemplo", 0, null, null, null));
                label2.Text = "Comienza a añadir libros pulsando en Añadir en el menú de la izquierda";
            }
            
        }

        // Importar Dynamic Link Libraries para arrastrar formularios
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void button1_Click(object sender, EventArgs e)
        {
            setBtnColors();
            btnShop.BackColor = Color.FromArgb(128, 179, 196);
        }

        private void setBtnColors()
        {

            btnHome.BackColor = Color.FromArgb(32, 32, 32);
            btnShop.BackColor = Color.FromArgb(32, 32, 32);
            btnAudioBooks.BackColor = Color.FromArgb(32, 32, 32);
            btnSettings.BackColor = Color.FromArgb(32, 32, 32);
            btnAdd.BackColor = Color.FromArgb(32, 32, 32);
            btnDelete.BackColor = Color.FromArgb(32, 32, 32);
            btnUser.BackColor = Color.FromArgb(32, 32, 32);
            btnMod.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            setBtnColors();
            btnHome.BackColor = Color.FromArgb(128, 179, 196);

        }

        private void btnAudioBooks_Click(object sender, EventArgs e)
        {
            setBtnColors();
            btnAudioBooks.BackColor = Color.FromArgb(128, 179, 196);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            setBtnColors();
            btnSettings.BackColor = Color.FromArgb(128, 179, 196);
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            m.cerrarConn();
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            setBtnColors();
            btnAdd.BackColor = Color.FromArgb(128, 179, 196);

            Agregar addForm = new Agregar();
            if (addForm.ShowDialog() == DialogResult.OK)
            {

                string tit = addForm.title;
                string aut = addForm.author;
                int pag = addForm.pages;
                int any = addForm.year;
                string idi = addForm.idiom;
                int libro_id = ultimoIdLibro + 1;
                string portada = addForm.portada;
                string contenido = addForm.contenido;  

                int autor_id;

                if (aut != null && aut != "") { //Si no se ha dejado por defecto el autor:

                    autor_id = m.existeAutor(aut); //Si devuelve su id, el autor está registrado, si es -1 no lo esta.

                    if (autor_id < 0) //Si el autor del Libro que vamos a añadir no está registrado en nuestra BD:
                    {
                        autor_id = ultimoIdAutor + 1;
                        autores.Add(new Autor(autor_id, aut, null));
                        try {
                            m.agregaAutor(autores[autores.Count - 1]);
                            ultimoIdAutor = autor_id;
                        } catch (Exception ex) {
                            MessageBox.Show("Fallo al añadir el Autor: #"+ autor_id + ". " + ex.Message);
                        }
                    }
                } else { 
                    //Autor se dejará por defecto en este libro:
                    autor_id = 0;
                }
                
                libros.Add(new Libro(libro_id, autor_id, pag, tit, any, idi, portada, contenido));

                try
                {
                    m.agregaLibro(libros[libros.Count - 1]);
                    ultimoIdLibro = libro_id;

                    vistaLibro vl = new vistaLibro();
                    int i = libros.Count - 1;

                    vl.setText(libros[i].titulo);
                    //vl.setBtnImage(libros[i].portada);
                    if (libros[i].portada != null) {
                        Bitmap bmp = new Bitmap(libros[i].portada);
                        vl.setBtnImage(bmp);
                    }
                    vl.cambiaColorEct(Color.FromArgb(255, 255, 255));

                    if (libros.Count > (TLP.RowCount*4))//Por si faltan filas para mostrar el nuevo libro   
                        TLP.RowCount = (int)Math.Ceiling(((double)libros.Count) / 4); 

                    TLP.Controls.Add(vl);
                    //Se añade el manejador al Control, para que llame a 'abreInfoLibros()' cuando le demos en el btn de dicho Ctrl.
                    vl.ManejadorClickEnBoton += new System.EventHandler(this.abreInfoLibros);
                    // Le damos al nuevo control personalizado los datos del libro del que es responsable:
                    vl.info_id = libros[i].libro_id;
                    vl.info_titulo = libros[i].titulo;
                    vl.info_autor = m.getAutorById(libros[i].autor_id).nombre;
                    vl.info_anyo = libros[i].anyo;
                    vl.info_portada = libros[i].portada;
                    vl.info_contenido = libros[i].contenido;

                    MessageBox.Show(libros[libros.Count - 1].titulo + " ha sido añadido exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fallo al añadir el libro: #" + libro_id + ".  " + ex.Message);
                }

                
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            setBtnColors();
            btnDelete.BackColor = Color.FromArgb(128, 179, 196);

            using (Eliminar eForm = new Eliminar())
            {
                foreach (Libro l in libros)
                {
                    eForm.setData(l.libro_id, l.titulo);
                }
                if (eForm.ShowDialog() == DialogResult.OK)
                {
                    //Elimino el libro de la BD:
                    m.eliminaLibro(eForm.id_eliminar);

                    /* Como he creado y metido los vistaLibro en TLP con el mismo orden que se encuentran en libros, averiguo el índice del que he borrado
                        para borrar el vistaLibro que lo muestra: */
                    int index = libros.FindIndex(r => r.libro_id == eForm.id_eliminar);
                    TLP.Controls.RemoveAt(index);

                    //eliminamos de la List local el libro con ID corresponidente al que acabamos de eliminar:
                    var itemToRemove = libros.Single(r => r.libro_id == eForm.id_eliminar);
                    libros.Remove(itemToRemove);

                    if (libros.Count == (TLP.RowCount * 4)-4)//Si sobran filas para mostrar los libros  
                        TLP.RowCount = (int)Math.Ceiling(((double)libros.Count) / 4);

                    MessageBox.Show("El libro con id: " + eForm.id_eliminar + " Se ha eliminado con éxito", "Confirmación");
                }
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            setBtnColors();
            btnUser.BackColor = Color.FromArgb(128, 179, 196);
        }

        public void muestraLibros()
        {
            //Redondea siempre hacia arriba: 
            TLP.RowCount = (int)Math.Ceiling(((double)libros.Count) / 4);
            foreach (Libro l in libros)
            {

                vistaLibro vl = new vistaLibro();

                if (l.portada != null && l.portada != "")
                {
                    Bitmap portada = new Bitmap(l.portada);
                    Image img = portada;
                    vl.setBtnImage(img);
                   
                }        

                vl.setText(l.titulo);
                vl.cambiaColorEct(Color.FromArgb(255, 255, 255));
                try
                {
                    vl.info_autor = m.getAutorById(l.autor_id).nombre;
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show("Error al extraer el autor de la base de datos.");
                }
                vl.info_id = l.libro_id;
                vl.info_titulo = l.titulo;
                vl.info_anyo = l.anyo;
                vl.info_portada = l.portada;
                vl.info_contenido = l.contenido;

                //vl.setBtnImage(l.portada);

                //Se añade el método como manejador
                vl.ManejadorClickEnBoton += new System.EventHandler(this.abreInfoLibros);

                TLP.Controls.Add(vl);
      
            }
        }

        //Método que se llamara cuando se clique en el botón de una 'vistaLibro'
        public void abreInfoLibros(object sender, EventArgs e)
        {

            vistaLibro vl = (vistaLibro) sender;

            int id = vl.info_id;
            string t = vl.info_titulo;
            string a = vl.info_autor;
            int y = vl.info_anyo;
            string p = vl.info_portada;
            string c = vl.info_contenido;

            using (infoLibros il = new infoLibros(t, a, y, p, c))
            {
                if (il.ShowDialog() == DialogResult.OK)
                {     //Le ha dado al botón eliminar del 'il'
                      //Nos disponemos a confirmar si quiere eliminarlo de la BD:
                    try
                    {
                        DialogResult dr = MessageBox.Show(this, "Estas seguro de que quieres eliminarlo?", "confirmación", MessageBoxButtons.YesNo);

                        if (dr == DialogResult.Yes)
                        {

                            m.eliminaLibro(id);

                            //Limpiamos el TLP del control que visualiza el libro eliminado:                           
                            int index = libros.FindIndex(r => r.libro_id == id);
                            TLP.Controls.RemoveAt(index);

                            //eliminamos de la List local el libro con ID corresponidente al que acabamos de eliminar:
                            var itemToRemove = libros.Single(r => r.libro_id == id);
                            libros.Remove(itemToRemove);

                            MessageBox.Show("Libro " + id.ToString() + " eliminado con éxito");

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Fallazo");
                    }
                }
            }
        }

       
        //Proceso desde que se hace click en btnMod hasta que (si se desea) se modifica un libro.
        private void btnMod_Click(object sender, EventArgs e)
        {
            setBtnColors();
            btnMod.BackColor = Color.FromArgb(128, 179, 196);
            
            using (Modificaciones mForm = new Modificaciones(libros, autores))
            {
                if (mForm.ShowDialog() == DialogResult.OK)
                {
                    Libro l = new Libro();
                    l.libro_id = mForm.id;
                    l.titulo = mForm.title; 
                    //FORMATEO AUTOR:
                    string aut = mForm.author;
                    //Si devuelve su id, el autor está registrado, si es -1 no lo esta.
                    int autor_id = m.existeAutor(aut);
                    //Si el autor del Libro que vamos a modificar no está registrado en nuestra BD:
                    if (autor_id < 0) 
                    {
                        autor_id = ultimoIdAutor + 1;
                        autores.Add(new Autor(autor_id, aut, null));
                        try
                        {
                            m.agregaAutor(autores[autores.Count - 1]);
                            ultimoIdAutor = autor_id; //Ahora el autor recién creado tiene el último id.
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fallo al añadir el Autor: #" + ex.Message);
                        }
                    }
                    l.autor_id = autor_id; 
                    l.paginas = mForm.pages;
                    l.anyo = mForm.year;
                    l.idioma = mForm.idiom;
                    l.portada = mForm.portada;
                    l.contenido = mForm.contenido;
                    //Siguiente bloque es para modificar el libro de la BD y de la lista local
                    try {
                        m.modificaLibro(l);
                        int index = libros.FindIndex(r => r.libro_id == l.libro_id);
                        libros[index] = l;

                        //Lo que resta es para reflejar los cambios en la vistaLibro en tiempo de ejecución:
                        TLP.Controls.RemoveAt(index);
                        vistaLibro vl = new vistaLibro();
                        int i = libros.Count - 1;

                        vl.setText(libros[index].titulo);
                        
                        //Establecer la portada como inagen del botón:
                        if (libros[index].portada != null)
                        {
                            Bitmap bmp = new Bitmap(libros[index].portada);
                            vl.setBtnImage(bmp);
                        }

                        vl.cambiaColorEct(Color.FromArgb(255, 255, 255));
                        TLP.Controls.Add(vl);
                        TLP.Controls.SetChildIndex(vl, index);
                        //Se añade el manejador al Control, para que llame a 'abreInfoLibros()' cuando le demos en el btn de dicho Ctrl.
                        vl.ManejadorClickEnBoton += new System.EventHandler(this.abreInfoLibros);

                        vl.info_id = libros[index].libro_id;
                        vl.info_titulo = libros[index].titulo;
                        vl.info_autor = m.getAutorById(libros[index].autor_id).nombre;
                        vl.info_anyo = libros[index].anyo;
                        vl.info_portada = libros[index].portada;
                        vl.info_contenido = libros[index].contenido;

                        MessageBox.Show("Libro: " + l.titulo + " con ID: " + l.libro_id + " Se ha modificado con éxito", "Confirmación");

                    } catch (Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                   
                }
            }
            
        }

       
    }
}
