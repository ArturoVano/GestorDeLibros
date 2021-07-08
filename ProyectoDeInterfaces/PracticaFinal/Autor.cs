using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal
{
    public class Autor
    {
        public Int32 autor_id { get; set; }
        public string nombre { get; set; }
        public string nacionalidad { get; set; }

        public Autor() { }
        public Autor(int id, string nom, string nacion) 
        {
            autor_id = id;
            nombre = nom;
            nacionalidad = nacion;
        }
        public Autor(int id, string nom) {
            autor_id = id;
            nombre = nom;
        }
    }
}
