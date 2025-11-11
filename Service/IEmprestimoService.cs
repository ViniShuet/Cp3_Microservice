using Domain;

namespace Service
{
    public interface IEmprestimoService
    {
        void registrarEmprestimo(Emprestimo emprestimo);

        Emprestimo ObterPorId(int id);

        List<Emprestimo> obterTodos();

        void atualizarEmprestimo(Emprestimo emprestimo);

        List<Emprestimo> obterPorUsuario(int usuarioId);
    }
}