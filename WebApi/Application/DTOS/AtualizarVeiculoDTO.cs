using TestePratico.WebApi.Domain.Enums;

namespace TestePratico.WebApi.Application.DTOS
{
    public class AtualizarVeiculoDTO
    {
        public string Descricao { get; set; }
        public Marca Marca { get; set; }
        public string Modelo { get; set; }
        public double Valor { get; set; }
    }
}
