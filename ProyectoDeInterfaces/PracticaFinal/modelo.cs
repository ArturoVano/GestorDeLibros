using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PracticaFinal
{


    class modelo
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        public modelo()
        {
            
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "192.168.0.42";
                builder.UserID = "arturo";
                builder.Password = "alumno";
                builder.Database = "bibliotecaDINT";

            conn = new MySqlConnection(builder.ToString());
            
            /*try
            {*/
                //Hace un ping al servidor y si el ping falla, abre la conexión otra vez.
                if (!conn.Ping())
                {
                    conn.Open();
                }
                cmd = conn.CreateCommand();
                
           /* }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {*/
                //throw e;
            //}
            
            
        }
        // MÉTODO que devuelve el id más alto de la tabla Libros, util para añadir nuevos Libros:
        public int getLastLibroId()
        {
            //conn.Close();    
            string sql = "SELECT MAX(libro_id) FROM Libros;";
            cmd = new MySqlCommand(sql, conn);
            /*MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@Tabla";
            param.Value = tabla;
            cmd.Parameters.Add(param);*/

            //ExecuteScalar: devuelve la primera columna de la primera fila del result set que devuelve la consulta:
            String d = cmd.ExecuteScalar().ToString();
            int id = Int32.Parse(d);
            
            return id;
        }
        // MÉTODO que devuelve el id más alto de la tabla Autores, util para añadir nuevos Autores:
        public int getLastAutorId()
        {
            //conn.Close();    
            string sql = "SELECT MAX(autor_id) FROM Autores;";
            cmd = new MySqlCommand(sql, conn);

            //ExecuteScalar: devuelve la primera columna de la primera fila del result set que devuelve la consulta:
            String d = cmd.ExecuteScalar().ToString();
            int id = Int32.Parse(d);

            return id;
        }

        public string[] getLibroById(int id) 
        {
            string[] valores = new string[8];
            try
            {
                //cmd.Parameters.Add("@id", MySqlDbType.Text).Value = 2;
                string sql = "SELECT * FROM Libros WHERE libro_id = " + id + ";";

                cmd = new MySqlCommand(sql, conn);

                //conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {

                    reader.Read();//Como el resultado será una sola fila, basta con un Read

                    if (reader[0] != null)
                        valores[0] = (string)reader[0].ToString();

                    if (reader[1] != null)
                        valores[1] = reader[1].ToString();

                    if (reader[2] != null)
                        valores[2] = reader[2].ToString();

                    if (reader[3] != null)
                        valores[3] = (string)reader[3];

                    if (reader[4] != null)
                        valores[4] = reader[4].ToString();

                    if (reader[5] != null)
                        valores[5] = (string)reader[5];

                    if (reader[6] != null)
                        valores[6] = (string)reader[6];

                    if (reader[7] != null)
                        valores[7] = (string)reader[7];


                    /*Libro l = new Libro();
                    l.libro_id = Int32.Parse(valores[0]);
                    l.autor_id = Int32.Parse(valores[1]);
                    l.paginas = Int32.Parse(valores[2]);
                    l.titulo = valores[3];
                    l.anyo = Int32.Parse(valores[4]);
                    l.idioma = valores[5];
                    l.contenido = valores[7];
                    return l; */

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //conn.Close();
            return valores;
        }


        // MÉTODO que devuelve una lista de todos los libros en la BD
        public List<Libro> getLibros()
        {
            //conn.Close();
            String sql = "SELECT * FROM Libros;";
            
            cmd = new MySqlCommand(sql, conn);
            //conn.Open();
            List<Libro> datos = new List<Libro>();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            { 
                while (reader.Read())
                {
                    Libro l = new Libro();
                    try
                    {
                        l.libro_id = Int32.Parse(reader[0].ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        l.autor_id = Int32.Parse(reader[1].ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        l.paginas = Int32.Parse(reader[2].ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        l.titulo = (string)reader[3];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        l.anyo = Int32.Parse(reader[4].ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        l.idioma = (string)reader[5];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        
                        l.portada = reader[6].ToString();
                            
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        l.contenido = (string)reader[7];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    //conn.Close();
                    datos.Add(l);
                }

                return datos;
            }  
        }

        // MÉTODO que devuelve una lista de todos los autores en la BD
        public List<Autor> getAutores()
        {
            
            String sql = "SELECT * FROM Autores;";

            cmd = new MySqlCommand(sql, conn);
            //conn.Open();
            List<Autor> datos = new List<Autor>();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Autor l = new Autor();
                    try
                    {
                        l.autor_id = Int32.Parse(reader[0].ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        l.nombre = reader[1].ToString();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        l.nacionalidad = (string)reader[2];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    datos.Add(l);
                }

                return datos;
            }
        }
        public Autor getAutorById(int id) {
            try
            {
                Autor a = new Autor();
                string sql = "SELECT * FROM Autores WHERE autor_id = @id;";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Text).Value = id;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Creacion del objeto Autor equivalente a la fila requerida:
                       // a = new Autor(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString());
                        a.autor_id = Int32.Parse(reader[0].ToString());
                        a.nombre = reader[1].ToString();
                        a.nacionalidad = reader[2].ToString();
                    }
                    return a;

                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex){
                throw ex;
            }
            
        }

        public Image Get_Finger_print(int id_libro)
        {
            try
            {
                string sql = "SELECT portada FROM Libros WHERE libro_id = @id;";
                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id_libro;

                conn.Open();
                  
                byte[] image = (byte[])cmd.ExecuteScalar();
                Image newImage = byteArrayToImage(image);

                return newImage;
            }
            catch (Exception ex) { throw ex; }
            //return null;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
  
                using (var mS = new MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(mS);
                }

              
        }

        // MÉTODO para insertar una imagen tipo Image como portada del id del libro pasado:
        public void insertaProtada(int libro_id, Image img)
        {
            using (var memStream = new MemoryStream()) //Clase de Stream para tratar con bytes.
            {
                img.Save(memStream, img.RawFormat);

                byte[] portada = memStream.ToArray();

                try
                {
                    string sql = " UPDATE Libros SET portada = @portada WHERE libro_id = @id;";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = libro_id;
                    cmd.Parameters.Add("@portada", MySqlDbType.Blob).Value = portada;

                    cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }  
        }


        //
        /*public void GetEmployee(string id_libro, string pfirstName)
        {
           

            string sql = "SELECT libro_id, portada FROM Libros WHERE libro_id = @id;";
            cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id_libro;
            

            FileStream fs;                          // Escribe el BLOB en un archivo (* .bmp).
            BinaryWriter bw;                        // Transmite el BLOB al objeto FileStream.
            int bufferSize = 100;                   // Tamaño del búfer BLOB.
            byte[] outbyte = new byte[bufferSize];  // El búfer de bytes BLOB [] que será llenado por GetBytes.
            long devolucion;                            // Los bytes devueltos por GetBytes.
            long startIndex = 0;                    // La posición inicial en la salida BLOB.
            string libro_id = "";                     // La identificación de libro que se usará en el nombre del archivo.

            // Abra la conexión y lea los datos en DataReader.
            conn.Open();
            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                // Obtiene la identificación del libro, que debe ocurrir antes de obtener el libro.
                libro_id = myReader.GetInt32(0).ToString();

                // Crea un archivo para contener la salida.
                fs = new FileStream("libro" + libro_id + ".bmp",FileMode.OpenOrCreate, FileAccess.Write);
                bw = new BinaryWriter(fs);

                // Restablece el byte inicial para el nuevo BLOB.
                startIndex = 0;

                // Leer los bytes en outbyte [] y retener el número de bytes devueltos.
                devolucion = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);

                // Continúe leyendo y escribiendo mientras haya bytes más allá del tamaño del búfer.
                while (devolucion == bufferSize)
                {
                    bw.Write(outbyte);
                    bw.Flush();

                    // Reposiciona el índice de inicio al final del último búfer y llena el búfer.
                    startIndex += bufferSize;
                    devolucion = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
                }

                // Escribe el búfer restante.
                bw.Write(outbyte, 0, (int)devolucion);
                bw.Flush();

                // Cierre el archivo de salida.
                bw.Close();
                fs.Close();
            }

            // Cierre el lector y la conexión.
            myReader.Close();
            conn.Close();
        }*/

        // PERSISTIR EN LA BASE DE DATOS NUEVOS LIBROS:

        public void agregaLibro(Libro l) 
        {
            try
            {
                string sql = "INSERT INTO Libros (libro_id, autor_id, n_paginas, titulo, año, idioma, portada, contenido )" +
                "VALUES (@id, @autor, @paginas, @titulo, @anyo, @idioma, @portada, @cont);";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = l.libro_id;
                cmd.Parameters.Add("@autor", MySqlDbType.Int32).Value = l.autor_id;
                cmd.Parameters.Add("@paginas", MySqlDbType.Int32).Value = l.paginas;
                cmd.Parameters.Add("@titulo", MySqlDbType.Text).Value = l.titulo;
                cmd.Parameters.Add("@anyo", MySqlDbType.Int32).Value = l.anyo;
                cmd.Parameters.Add("@idioma", MySqlDbType.Text).Value = l.idioma;
                cmd.Parameters.Add("@portada", MySqlDbType.Text).Value = l.portada;
                cmd.Parameters.Add("@cont", MySqlDbType.Text).Value = l.contenido;
                
                //conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregaAutor(Autor a)
        {
            try
            {   
                if (!string.IsNullOrEmpty(a.nacionalidad)) //Para evitar problemas con el posible valor nulo
                {
                    string sql = "INSERT INTO Autores (autor_id, nombre, nacionalidad)" +
                        "VALUES (@autor_id, @nombre, @nacionalidad);";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add("@nacionalidad", MySqlDbType.Text).Value = a.nacionalidad;
                    cmd.Parameters["nacionalidad"].IsNullable = true;
                }
                else
                {
                    string sql = "INSERT INTO Autores (autor_id, nombre)" +
                        "VALUES (@autor_id, @nombre);";
                    cmd = new MySqlCommand(sql, conn);
                }
                cmd.Parameters.Add("@autor_id", MySqlDbType.Int32).Value = a.autor_id;
                cmd.Parameters.Add("@nombre", MySqlDbType.Text).Value = a.nombre; 

                
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ELIMINAR DATOS DE LA BD:
        public void eliminaLibro(Libro l) {

            string sql = "DELETE from Libros WHERE libro_id = @id";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = l.libro_id;
            cmd.ExecuteScalar();
        }

        public void eliminaLibro(int libro_id) {

            try {

                string sql = "DELETE from Libros WHERE libro_id = @id";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = libro_id;
                cmd.ExecuteScalar();
            } catch (Exception ex) 
            {
                throw ex;
            }
        }

        public void eliminaAutor(Autor a) {
            try {
                string sql = "DELETE from Autores WHERE autor_id = @id";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = a.autor_id;
                cmd.ExecuteScalar();
            } 
            catch (Exception ex) {
                throw ex;
            }
            
        }

        public void eliminaAutor(int autor_id) {
            try {
                string sql = "DELETE from Autores WHERE autor_id = @id";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = autor_id;
                cmd.ExecuteScalar();

            } catch (Exception ex) {
                throw ex;
            }
            
        }

        // MODIFICAR DATOS DE LA BD:

        public void modificaLibro(Libro l)
        {
            try {

                int id = l.libro_id;
                string sql = "UPDATE Libros SET autor_id = @autor, n_paginas = @pag, titulo = @tit, año = @anyo, " +
                    "idioma = @idioma, portada = @portada, contenido = @cont WHERE libro_id = @id;";
                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = l.libro_id;
                cmd.Parameters.Add("@autor", MySqlDbType.Int32).Value = l.autor_id;
                cmd.Parameters.Add("@pag", MySqlDbType.Int32).Value = l.paginas;
                cmd.Parameters.Add("@tit", MySqlDbType.Text).Value = l.titulo;
                cmd.Parameters.Add("@anyo", MySqlDbType.Int32).Value = l.anyo;
                cmd.Parameters.Add("@idioma", MySqlDbType.Text).Value = l.idioma;
                cmd.Parameters.Add("@portada", MySqlDbType.Text).Value = l.portada;
                cmd.Parameters.Add("@cont", MySqlDbType.LongBlob).Value = l.contenido;

                cmd.ExecuteScalar();

            } catch (Exception ex) {
                throw ex;
            } 
        }
        

        // OTROS MÉTODOS:

        // Averiguar si existe un autor con determinado id pasado por parámetro:
        public bool existeAutor(int id)
        {      
            string sql = "SELECT autor_id FROM Autores WHERE autor_id = @id;";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            if (cmd.ExecuteScalar() == null)
                return false;
            else
                return true;
        }
        // Averiguar si existe un autor con determinado nombre pasado por parámetro, si existe devuelve su id, si no devuelve negativo:
        public int existeAutor(string nombre)
        {   
            string sql = "SELECT autor_id FROM Autores WHERE nombre = @nombre;";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@nombre", MySqlDbType.Text).Value = nombre.Trim();
            
            // Hacer conversiones directas me daba muchos problemas
            Object o = cmd.ExecuteScalar();
            
            if (o != null)
            {
                string res = o.ToString();
                return Int32.Parse(res);
            } 
            else
                return -1;
        }

        public bool cerrarConn()
        {  
            try
            {
               
                conn.Close();
                return true;   
            }
            catch (MySqlException)
            {
                return false;
            }
        }
       
        
    }   
}
