using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.WebApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNasc { get; set; }
    }
}
