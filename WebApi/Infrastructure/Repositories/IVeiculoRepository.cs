using Microsoft.EntityFrameworkCore;
using TestePratico.WebApi.Application.Interfaces;
using TestePratico.WebApi.Domain.Entities;

namespace TestePratico.WebApi.Infrastructure.Repositories
{
    public class VeiculoRepository(AppDbContext context) : IVeiculoRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AtualizarAsync(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<Veiculo> CriarAsync(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return veiculo;
        }

        public async Task DeletarAsync(int id)
        {
            var veiculoParaDeletar = await _context.Veiculos.FindAsync(id);

            if (veiculoParaDeletar != null)
            {
                _context.Veiculos.Remove(veiculoParaDeletar);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Veiculo>> Listar()
        {
            return await _context.Veiculos.ToListAsync();
        }

        public async Task<Veiculo> ObterPorId(int id)
        {
            return await _context.Veiculos.FindAsync(id);
        }
    }
}
