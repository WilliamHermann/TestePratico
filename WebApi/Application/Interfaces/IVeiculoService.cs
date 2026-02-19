using TestePratico.WebApi.Application.DTOS;
using TestePratico.WebApi.Domain.Entities;

namespace TestePratico.WebApi.Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<Veiculo> CriarAsync(CadastrarVeiculoDTO cadastrarVeiculoDTO);
        Task AtualizarAsync(Veiculo veiculoExistente, AtualizarVeiculoDTO dadosAtualizadoVeiculo);
        Task DeletarAsync(int id);
        Task<Veiculo> ObterPorIdAsync(int id);
        Task<IEnumerable<Veiculo>> ListarAsync();
    }
}
