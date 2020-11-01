using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.WebApp.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Título { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
    }
}
