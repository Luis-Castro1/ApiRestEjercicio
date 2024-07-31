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
            return await QueryAsync<PersonaEntity>("RecuperarPersonas");
        }
        public async Task<PersonaEntity> GetPersonaByIdAsync(int idPersona)
        {
           return await QueryFirstOrDefaultAsync<PersonaEntity>("RecuperarPersonaPorId", new { IdPersona = idPersona });
        }

        public async Task<PersonaEntity> AddPersonaAsync(CrearPersonaEntity nuevaPersona)
        {

            var PersonaCreada =  await QueryFirstOrDefaultAsync<PersonaEntity>("CrearPersona",
                new
                {
                    Nombre = nuevaPersona.Nombre,
                    Apellido = nuevaPersona.Apellido,
                    Email = nuevaPersona.Email,
                    Telefono = nuevaPersona.Telefono,
                    Direccion = nuevaPersona.Direccion,
                    Edad = nuevaPersona.Edad
                }     
            );

            return PersonaCreada;
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
