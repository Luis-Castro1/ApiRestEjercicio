using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IPersonaRepository
    {
        Task <PersonaEntity>AddPersonaAsync(CrearPersonaEntity persona);
        Task<IEnumerable<PersonaEntity>> GetPersonasAsync();
        Task<PersonaEntity> GetPersonaByIdAsync(int idPersona);
        Task UpdatePersonaAsync(PersonaEntity persona);
        Task DeletePersonaAsync(int id);
    }
}
