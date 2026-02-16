using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TestePratico.WebApi.Application.DTOS;
using TestePratico.WebApi.Application.Services;
using TestePratico.WebApi.Domain.Entities;

namespace TestePratico.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/veiculos")]
    public class VeiculosController : ControllerBase
    {
        private readonly IValidator<Veiculo> _validator;
        private readonly VeiculoService _veiculoService;
        
        public VeiculosController(IValidator<Veiculo> validator,VeiculoService veiculoService)
        {
            _validator = validator;
            _veiculoService = veiculoService;
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> Cadastrar([FromBody]CadastrarVeiculoDTO cadastrarVeiculoDTO)
        {
            var novoVeiculo = new Veiculo
            {
                Descricao = cadastrarVeiculoDTO.Descricao,
                Marca = cadastrarVeiculoDTO.Marca,
                Modelo = cadastrarVeiculoDTO.Modelo,
                Valor = cadastrarVeiculoDTO.Valor
            };

            var resultado = await _validator.ValidateAsync(novoVeiculo);

            if (resultado.IsValid is false)
            {
                return BadRequest(resultado.Errors.Select(e => e.ErrorMessage));
            }

            var veiculoCriado = await _veiculoService.CriarAsync(novoVeiculo);

            return CreatedAtAction(nameof(ObterVeiculoPorId), new { id = veiculoCriado.Id }, veiculoCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarVeiculoDTO atualizarVeiculoDTO)
        {
            var dadosAtualizadoVeiculo = new Veiculo
            {
                Descricao = atualizarVeiculoDTO.Descricao,
                Marca = atualizarVeiculoDTO.Marca,
                Modelo = atualizarVeiculoDTO.Modelo,
                Valor = atualizarVeiculoDTO.Valor
            };

            var resultado = await _validator.ValidateAsync(dadosAtualizadoVeiculo);

            if (resultado.IsValid is false)
            {
                return BadRequest(resultado.Errors.Select(e => e.ErrorMessage));
            }

            var veiculoExistente = await _veiculoService.ObterPorIdAsync(id);

            if (veiculoExistente is null)
            {
                return NotFound();
            }

            await _veiculoService.AtualizarAsync(veiculoExistente, dadosAtualizadoVeiculo);

            return Ok(veiculoExistente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> ObterVeiculoPorId(int id)
        {
            var veiculo = await _veiculoService.ObterPorIdAsync(id);

            if (veiculo is null)
            {
                return NotFound();
            }
            
            return Ok(veiculo); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> Listar()
        {
            var veiculos = await _veiculoService.ListarAsync();

            if (veiculos.Any() is false)
            {
                return NoContent();
            }

            return Ok(veiculos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var veiculo = await _veiculoService.ObterPorIdAsync(id);

            if (veiculo is null)
            {
                return NotFound();
            }

            await _veiculoService.DeletarAsync(id);

            return Ok();
        }
    }
}
