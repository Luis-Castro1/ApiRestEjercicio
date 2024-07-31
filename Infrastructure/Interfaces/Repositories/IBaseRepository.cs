using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IBaseRepository<PersonaEntity> where PersonaEntity : class
    {
        ValueTask<PersonaEntity> GetByIdAsync(int IdPersona);
        Task<IEnumerable<PersonaEntity>> GetAllAsync();
        Task AddAsync(PersonaEntity NuevaPersona);
        void Remove(int IdPersona);
        Task Update(PersonaEntity PersonaAModificar);
    }
}
