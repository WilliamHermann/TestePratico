using FluentValidation;
using TestePratico.WebApi.Domain.Entities;

namespace TestePratico.WebApi.Domain.Validations
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
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
