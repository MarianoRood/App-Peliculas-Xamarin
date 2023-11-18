using System;
using System.Collections.Generic;
using System.Text;

namespace AppCineMax.Models
{
    public class Pelicula
    {
        public int id { get; set; }
        public string title { get; set; }
        public int director_id { get; set; }
        public int duration { get; set; }
        public int categorie_id { get; set; }
        public string sipnosis { get; set; }
        public string path_img { get; set; }
        public Categoria categorias { get; set; }
        public Director director { get; set; }
    }
}
