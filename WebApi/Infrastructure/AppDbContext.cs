using Microsoft.EntityFrameworkCore;
using TestePratico.WebApi.Domain.Entities;

namespace TestePratico.WebApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
