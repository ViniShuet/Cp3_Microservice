using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;
        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> cadastrarLivroAsync(Livro livro)
        {
            if(string.IsNullOrWhiteSpace(livro.ISBN))
            {
                throw new Exception("ISBN é obrigatório");
            }

            if (string.IsNullOrWhiteSpace(livro.titulo))
            {
                throw new Exception("Título é obrigatório");
            }

            if (string.IsNullOrWhiteSpace(livro.autor))
            {
                throw new Exception("Autor é obrigatório");
            }

            if (string.IsNullOrWhiteSpace(livro.categoria))
            {
                throw new Exception("Categoria é obrigatório");
            }

            livro.statusLivro = "Disponivel";

            livro.dataCadastro = DateTime.Now;

            return await _repository.addAsync(livro);

        }

        public async Task atualizarStatusAsync(int id, string novoStatus)
        {
            var livro = await _repository.obterPorIdAsync(id);
            if (livro == null)
            {
                throw new Exception("Livro não encontrado");
            }

            var statusPermitidos = new[] { "Disponivel", "Emprestado", "Reservado" };

            novoStatus = novoStatus.ToUpper();

            if (!statusPermitidos.Contains(novoStatus))
            {
                throw new Exception("Status inválido");
            }

            //Regra de negocio
            //Livro emprestado nao pode ser reservado

            if(livro.status == "Emprestado" && novoStatus == "Reservado")
            {
                throw new Exception("Livro emprestado não poded ser reservado");
            }

            livro.status = novoStatus;
            await _repository.saveAsync(livro);
        }

        public async Task<Livro> obterPorIdAsync(int id)
        {
            return await _repository.obterPorIdAsync(id);
        }

        public async Task<IEnumerable<Livro>> listarLivrosAsync()
        {
            return await _repository.ObterTodosAsync();
        }
    }
}
