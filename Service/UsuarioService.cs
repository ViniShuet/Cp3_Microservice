using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly ILivroRepository _livroRepository;

        public UsuarioService(IUsuarioRepository repository, ILivroRepository livroRepository)
        {
            _repository = repository;
            _livroRepository = livroRepository;
        }

        public async Task<int> CadastrarUsuarioAsync(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.nome))
                throw new Exception("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.email))
                throw new Exception("E-mail é obrigatório.");

            var tiposValidos = new[] { "ALUNO", "PROFESSOR", "FUNCIONARIO" };
            if (!tiposValidos.Contains(usuario.tipo.ToUpper()))
                throw new Exception("Tipo de usuário inválido.");

            usuario.dataCadastro = DateTime.Now;

            return await _repository.AddAsync(usuario);
        }

        public async Task VerificarLimiteEmprestimosAsync(int usuarioId)
        {
            var usuario = await _repository.ObterPorIdAsync(usuarioId);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            var livrosEmprestados = await _livroRepository.ObterLivrosEmprestadosPorUsuarioAsync(usuarioId);
            int emprestimosAtivos = livrosEmprestados.Count(l => l.Status == "EMPRESTADO");

            if (emprestimosAtivos >= 3)
                throw new Exception($"Usuário {usuario.Nome} já possui {emprestimosAtivos} empréstimos ativos. Limite máximo de 3.");
        }

        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Usuario>> ListarUsuariosAsync()
        {
            return await _repository.ObterTodosAsync();
        }
    }
}