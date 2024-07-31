using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLuisEjercicio2.Models;
using Domain.Entities;

namespace Application.Mapping
{
    public static class PersonaMapping
    {
        public static PersonaModel ToModel (this  PersonaEntity entity)
        {
            return new PersonaModel
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Edad = entity.Edad,
                Email = entity.Email,
                Telefono = entity.Telefono,
                Direccion = entity.Direccion,
            };
        }

        public static IEnumerable<PersonaModel> ToModel(this IEnumerable<PersonaEntity> entities)
        {
            foreach (var entity in entities)
            {
                yield return entity.ToModel();
            }
        }
    }
}
