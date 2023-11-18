using System;
using System.Collections.Generic;
using System.Text;

namespace AppCineMax.Models
{
    public class Funcion
    {
        public int id { get; set; }
        public int pelicula_id { get; set; }
        public int sala_id { get; set; }
        public string hour_function { get; set; }
        public string date_function { get; set; }
        public Pelicula peliculas { get; set; }
        public Sala salas { get; set; }
    }
}
