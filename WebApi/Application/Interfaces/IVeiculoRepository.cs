using TestePratico.WebApi.Domain.Entities;

namespace TestePratico.WebApi.Application.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> CriarAsync(Veiculo veiculo);
        Task AtualizarAsync(Veiculo veiculo);
        Task DeletarAsync(int id);
        Task<Veiculo> ObterPorId(int id);
        Task<IEnumerable<Veiculo>> Listar();
    }
}
