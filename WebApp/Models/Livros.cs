using System;
using System.Collections.Generic;

namespace Livraria.WebApp.Models
{
    public partial class Livros
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
    }
}
