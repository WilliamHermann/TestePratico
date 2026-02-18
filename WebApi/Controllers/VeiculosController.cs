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
        private readonly IValidator<CadastrarVeiculoDTO> _cadastrarValidator;
        private readonly IValidator<AtualizarVeiculoDTO> _atualizarValidator;
        private readonly VeiculoService _veiculoService;
        
        public VeiculosController(IValidator<CadastrarVeiculoDTO> cadastrarValidator, IValidator<AtualizarVeiculoDTO> atualizarValidator, VeiculoService veiculoService)
        {
            _cadastrarValidator = cadastrarValidator;
            _atualizarValidator = atualizarValidator;
            _veiculoService = veiculoService;
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> Cadastrar([FromBody]CadastrarVeiculoDTO cadastrarVeiculoDTO)
        {
            var resultado = await _cadastrarValidator.ValidateAsync(cadastrarVeiculoDTO);

            if (resultado.IsValid is false)
            {
                return BadRequest(resultado.Errors.Select(e => e.ErrorMessage));
            }

            var veiculoCriado = await _veiculoService.CriarAsync(cadastrarVeiculoDTO);

            return CreatedAtAction(nameof(ObterVeiculoPorId), new { id = veiculoCriado.Id }, veiculoCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarVeiculoDTO atualizarVeiculoDTO)
        {
            var resultado = await _atualizarValidator.ValidateAsync(atualizarVeiculoDTO);

            if (resultado.IsValid is false)
            {
                return BadRequest(resultado.Errors.Select(e => e.ErrorMessage));
            }

            var veiculoExistente = await _veiculoService.ObterPorIdAsync(id);

            if (veiculoExistente is null)
            {
                return NotFound();
            }

            await _veiculoService.AtualizarAsync(veiculoExistente, atualizarVeiculoDTO);

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
