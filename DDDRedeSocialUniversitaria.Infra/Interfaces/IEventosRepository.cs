using System.Collections.Generic;
using System.Threading.Tasks;
using DDDRedeSocialUniversitaria.Domain;

namespace DDDRedeSocialUniversitaria.Infra.Interfaces
{
    public interface IEventosRepository
    {
        Task<IEnumerable<Evento>> GetAllAsync();
        Task<Evento> GetByIdAsync(int id);
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);
    }
}
