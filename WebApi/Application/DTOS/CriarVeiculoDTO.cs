using System.ComponentModel.DataAnnotations;
using TestePratico.WebApi.Domain.Enums;

namespace TestePratico.WebApi.Application.DTOS
{
    public class CadastrarVeiculoDTO
    {
        public string Descricao { get; set; }
        public Marca Marca { get; set; }
        public string Modelo { get; set; }
        public double Valor { get; set; }
    }
}
