using System.Collections.Generic;
using System.Threading.Tasks;
using DDDRedeSocialUniversitaria.Domain;
using DDDRedeSocialUniversitaria.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDDRedeSocialUniversitaria.Infra.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly SqlContext _context;

        public PostagemRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Postagem>> GetAllAsync()
        {
            return await _context.Postagens.AsNoTracking().ToListAsync();
        }

        public async Task<Postagem> GetByIdAsync(int id)
        {
            return await _context.Postagens.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Postagem postagem)
        {
            await _context.Postagens.AddAsync(postagem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Postagem postagem)
        {
            _context.Postagens.Update(postagem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var postagem = await GetByIdAsync(id);
            if (postagem != null)
            {
                _context.Postagens.Remove(postagem);
                await _context.SaveChangesAsync();
            }
        }
    }
}