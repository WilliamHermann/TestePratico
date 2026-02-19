using TestePratico.WebApi.Application.DTOS;
using TestePratico.WebApi.Application.Interfaces;
using TestePratico.WebApi.Domain.Entities;

namespace TestePratico.WebApi.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Veiculo> CriarAsync(CadastrarVeiculoDTO cadastrarVeiculoDTO)
        {
            var novoVeiculo = new Veiculo
            {
                Descricao = cadastrarVeiculoDTO.Descricao,
                Marca = cadastrarVeiculoDTO.Marca,
                Modelo = cadastrarVeiculoDTO.Modelo,
                Valor = cadastrarVeiculoDTO.Valor
            };

            return await _veiculoRepository.CriarAsync(novoVeiculo);
        }

        public async Task AtualizarAsync(Veiculo veiculoExistente, AtualizarVeiculoDTO dadosAtualizadoVeiculo)
        {
            veiculoExistente.Descricao = dadosAtualizadoVeiculo.Descricao;
            veiculoExistente.Marca = dadosAtualizadoVeiculo.Marca;
            veiculoExistente.Modelo = dadosAtualizadoVeiculo.Modelo;
            veiculoExistente.Valor = dadosAtualizadoVeiculo.Valor;

            await _veiculoRepository.AtualizarAsync(veiculoExistente);
        }

        public async Task DeletarAsync(int id)
        {
            await _veiculoRepository.DeletarAsync(id);
        }

        public async Task<Veiculo> ObterPorIdAsync(int id)
        {
            return await _veiculoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Veiculo>> ListarAsync()
        {
            return await _veiculoRepository.Listar();
        }

    }
}
