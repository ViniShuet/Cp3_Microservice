using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Multa
    {
        public Emprestimo idEmprestimo {  get; set; }

        public int valorMulta { get; set; }

        public string statusMulta {  get; set; } //pendente ou paga
    }
}
