using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly List<Emprestimo> _emprestimo = new();

        public void registrarEmprestimo(Emprestimo emprestimo)
        {
            _emprestimo.Add(emprestimo);
        }

        public Emprestimo ObterPorId(int id)
        {
            return _emprestimo.FirstOrDefault(e => e.idEmprestimo == id);
        }

        public List<Emprestimo> obterTodos()
        {
            return _emprestimo;
        }

        public void atualizarEmprestimo(Emprestimo emprestimo)
        {
            var existente = ObterPorId(emprestimo.idEmprestimo);

            if (existente != null)
            {
                existente.dataPrevistaDevolucao = emprestimo.dataRealDevolucao;
                existente.statusEmprestimo = emprestimo.statusEmprestimo;
            }
        }

        public List<Emprestimo> obterPorUsuario(int usuarioId)
        {
            return _emprestimo.Where(e => e.Usuario.id == usuarioId).ToList();
        }

    }
}
