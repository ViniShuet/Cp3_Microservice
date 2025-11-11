using Domain;

namespace Service
{
    public interface ILivroService
    {
        Task<int> cadastrarLivroAsync(Livro livro);

        Task atualizarStatusAsync(int id, string novoStatus);

        Task<Livro> obterPorIdAsync(int id);

        Task<IEnumerable<Livro>> listarLivrosAsync();
    }
}