// Infrastructure/Repositories/PersonaAbstract.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public abstract class PersonaAbstract
    {
        private readonly string _connectionString;

        protected PersonaAbstract(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        protected async Task<IEnumerable<T>> CrearPersona<T>(string storedProcedure, CrearPersonaEntity nuevaPersona)
        {
            try
            {
                using var connection = GetConnection();
                using var command = CreateCommand(connection, storedProcedure, nuevaPersona);
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                var results = new List<T>();

                while (await reader.ReadAsync())
                {
                    var Persona = MapReaderToEntity<T>(reader);
                    results.Add(Persona);
                }

                await connection.CloseAsync();
                return results;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string storedProcedure, object parameters = null)
        {
            try
            {

            using var connection = GetConnection();
            using var command = CreateCommand(connection, storedProcedure, parameters);
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            var results = new List<T>();

            while (await reader.ReadAsync())
            {
                var result = MapReaderToEntity<T>(reader);
                results.Add(result);
            }

            await connection.CloseAsync();
            return results;

            }
            catch(ArgumentException ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string storedProcedure, object parameters = null)
        {
            using var connection = GetConnection();
            using var command = CreateCommand(connection, storedProcedure, parameters);
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            T result = default;

            if (await reader.ReadAsync())
            {
                result = MapReaderToEntity<T>(reader);
            }

            await connection.CloseAsync();
            return result;
        }

        private SqlCommand CreateCommand(SqlConnection connection, string storedProcedure, object parameters)
        {
            var command = new SqlCommand(storedProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                foreach (var property in parameters.GetType().GetProperties())
                {
                    var parameter = new SqlParameter
                    {
                        ParameterName = property.Name,
                        Value = property.GetValue(parameters) ?? DBNull.Value
                    };
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        private T MapReaderToEntity<T>(IDataRecord reader)
        {
            var entity = Activator.CreateInstance<T>();

            foreach (var property in typeof(T).GetProperties())
            {
                if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                {
                    property.SetValue(entity, reader.GetValue(reader.GetOrdinal(property.Name)));
                }
            }

            return entity;
        }
    }
}
