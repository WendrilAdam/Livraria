using System;
using System.Collections.Generic;

namespace Livraria.WebApp
{
    public partial class Clientes
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime Dtnasc { get; set; }
    }
}
