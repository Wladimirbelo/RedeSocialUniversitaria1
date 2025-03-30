using System.Collections.Generic;
using System.Threading.Tasks;
using DDDRedeSocialUniversitaria.Domain;
using DDDRedeSocialUniversitaria.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDDRedeSocialUniversitaria.Infra.Repositories
{
    public class EventoRepository : IEventosRepository

    {
        private readonly SqlContext _context;

        public EventoRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            return await _context.Eventos.AsNoTracking().ToListAsync();
        }

        public async Task<Evento> GetByIdAsync(int id)
        {
            return await _context.Eventos.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Evento evento)
        {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var evento = await GetByIdAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
                await _context.SaveChangesAsync();
            }
        }
    }
}