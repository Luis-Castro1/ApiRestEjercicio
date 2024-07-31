using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Services
{
    public interface IPersonaService
    {
        Task <PersonaEntity> AddPersonaAsync(CrearPersonaEntity persona);
        Task DeletePersonaAsync(int id);
        Task<PersonaEntity> GetPersonaByIdAsync(int id);
        Task<IEnumerable<PersonaEntity>> GetPersonasAsync();
        Task UpdatePersonaAsync(PersonaEntity persona);
    }
}
