using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class Emprestimo
    {
        public int idEmprestimo {  get; set; }

        public Livro ISBN { get; set; }

        public Usuario id { get; set; }

        public string dataEmprestimo { get; set; }

        public string dataPrevistaDevolucao { get; set; }

        public string dataRealDevolucao { get; set; }

        public string statusEmprestimo {  get; set; } //ativo, finalizado ou atrasado
     
    }
}
