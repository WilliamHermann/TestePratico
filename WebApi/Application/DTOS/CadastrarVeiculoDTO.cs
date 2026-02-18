using TestePratico.WebApi.Domain.Enums;

namespace TestePratico.WebApi.Application.DTOS
{
    // Poderia usar somente uma record para criar e atualizar, mas deixei separado pois normalmente temos regras de validação diferentes em cada operação
    public record CadastrarVeiculoDTO(string Descricao, Marca Marca, string Modelo, double Valor);

}
