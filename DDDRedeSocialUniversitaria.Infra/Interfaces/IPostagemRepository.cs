using DDDRedeSocialUniversitaria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRedeSocialUniversitaria.Infra.Interfaces
{
    public interface IPostagemRepository
    {
        Task<IEnumerable<Postagem>> GetAllAsync();
        Task<Postagem> GetByIdAsync(int id);
        Task AddAsync(Postagem postagem);
        Task UpdateAsync(Postagem postagem);
        Task DeleteAsync(int id);
    }
}
