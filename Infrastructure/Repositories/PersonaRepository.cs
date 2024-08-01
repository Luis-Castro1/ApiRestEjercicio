using ApiLuisEjercicio2.Response;
using Azure;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

        public async Task<PersonaResponse> AddPersonaAsync(CrearPersonaEntity nuevaPersona)
        {
            PersonaResponse response = new PersonaResponse();
            try
            {
            var PersonaCreada = await CrearPersona<PersonaEntity>("CrearPersona", nuevaPersona);
            response.Result = PersonaCreada;
            response.IsSuccess = true;
            response.Message = "Persona creada correctamente";

            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            
            return response;
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
