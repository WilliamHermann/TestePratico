using System.ComponentModel.DataAnnotations;
using TestePratico.WebApi.Domain.Enums;

namespace TestePratico.WebApi.Domain.Entities
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Marca Marca { get; set; }
        public string Modelo { get; set; }
        public double Valor { get; set; }

    }
}
