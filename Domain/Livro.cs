using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Livro 
    {
        public string ISBN { get; set; }

        public string titulo { get; set; }

        public string autor {  get; set; }

        public string categoria { get; set; } //ficcao, tecnico ou didatico

        public string statusLivro { get; set; } //disponivel, emprestado ou reservado

        public DateTime dataCadastro { get; set; }

    }

}