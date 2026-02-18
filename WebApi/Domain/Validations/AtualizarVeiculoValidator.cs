using FluentValidation;
using TestePratico.WebApi.Application.DTOS;

namespace TestePratico.WebApi.Domain.Validations
{
    // Poderia usar somente uma classe de validação para criar e atualizar, mas deixei separado pois normalmente temos regras de validação diferentes em cada operação
    public class AtualizarVeiculoValidator : AbstractValidator<AtualizarVeiculoDTO>
    {
        public AtualizarVeiculoValidator()
        {
            RuleFor(v => v.Descricao)
                .MaximumLength(100)
                .NotEmpty();
            RuleFor(v => v.Marca)
                .IsInEnum();
            RuleFor(v => v.Modelo)
                .MaximumLength(30)
                .NotEmpty();
        }
    }
}
