// Application/Services/PersonaService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;

namespace Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public Task<int> AddPersonaAsync(PersonaEntity persona)
        {
            return _personaRepository.AddPersonaAsync(persona);
        }

        public Task DeletePersonaAsync(int id)
        {
            return _personaRepository.DeletePersonaAsync(id);
        }

        public Task<PersonaEntity> GetPersonaByIdAsync(int id)
        {
            return _personaRepository.GetPersonaByIdAsync(id);
        }

        public Task<IEnumerable<PersonaEntity>> GetPersonasAsync()
        {
            return _personaRepository.GetPersonasAsync();
        }

        public Task UpdatePersonaAsync(PersonaEntity persona)
        {
            return _personaRepository.UpdatePersonaAsync(persona);
        }
    }
}
