using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal
{
    public class Libro
    {
        public Int32 libro_id { get; set;}
        public Int32 autor_id { get; set;}
        public Int32 paginas { get; set ;}
        public string titulo { get; set ;}
        public Int32 anyo { get; set;}
        public string idioma { get; set;}
        public string portada { get; set;}
        public string contenido { get; set; }

        public Libro() { }
        public Libro(Int32 id, Int32 autor, Int32 paginas, string titulo, Int32 anyo, string idioma, string portada, string cont)
        {
            libro_id = id;
            autor_id = autor;
            this.paginas = paginas;
            this.titulo = titulo;
            this.anyo = anyo;
            this.idioma = idioma;
            this.portada = portada;
            contenido = cont;
        }

        public Libro(Int32 id, string titulo)
        {
            libro_id = id;
            this.titulo = titulo;
            
        }
    }
}
