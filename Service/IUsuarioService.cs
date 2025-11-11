using Domain;

namespace Service
{
    public interface IUsuarioService
    {
        Task<int> CadastrarUsuarioAsync(Usuario usuario);

        Task VerificarLimiteEmprestimosAsync(int usuarioId);

        Task<Usuario> ObterPorIdAsync(int id);

        Task<IEnumerable<Usuario>> ListarUsuariosAsync();
    }
}