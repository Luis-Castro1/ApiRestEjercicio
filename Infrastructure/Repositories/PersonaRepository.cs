using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonaRepository : PersonaAbstract, IPersonaRepository
    {
        //private readonly IDbConnection _dbConnection;

        public PersonaRepository(string connectionString) : base(connectionString)
        {
        }
        public async Task<IEnumerable<PersonaEntity>> GetPersonasAsync()
        {
            return await QueryAsync<PersonaEntity>("ListarPersonas");
        }
        public async Task<PersonaEntity> GetPersonaByIdAsync(int idPersona)
        {
           return await QueryFirstOrDefaultAsync<PersonaEntity>("RecuperarPersonaPorId", new { IdPersona = idPersona });
        }

        public Task<int> AddPersonaAsync(PersonaEntity nuevaPersona)
        {
            throw new NotImplementedException();
        }

        public Task DeletePersonaAsync(int idPersona)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonaAsync(PersonaEntity PersonaAModificar)
        {
            throw new NotImplementedException();
        }
    }
}
