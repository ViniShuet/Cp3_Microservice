using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string tipo { get; set; } //aluno, professor ou funcionario

        public DateTime dataCadastro { get; set; }
    }
}
