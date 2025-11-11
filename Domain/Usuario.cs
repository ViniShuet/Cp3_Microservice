using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class Usuario
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string tipo { get; set; } //aluno, professor ou funcionario

        public string dataCadastro { get; set; }
    }
}
