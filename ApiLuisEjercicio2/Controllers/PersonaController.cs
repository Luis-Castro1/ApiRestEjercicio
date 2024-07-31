// Api/Controllers/PersonasController.cs
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Interfaces.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonasController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaEntity>>> GetPersonas()
        {
            var personas = await _personaService.GetPersonasAsync();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaEntity>> GetPersona(int id)
        {
            var persona = await _personaService.GetPersonaByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PersonaEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaEntity>> AddPersona([FromBody] CrearPersonaEntity persona)
        {
            try
            {
            var PersonaCreada = await _personaService.AddPersonaAsync(persona);

            if (PersonaCreada == null)
            {
                return BadRequest(error: "No se pudo crear la persona");
            }

            var uri = new Uri($"{Request.Scheme}://{Request.Host}/api/Personas/{PersonaCreada.Id}");

            return Created(uri, PersonaCreada);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersona(int id, [FromBody] PersonaEntity persona)
        {
            if (id != persona.Id)
            {
                return BadRequest();
            }
            await _personaService.UpdatePersonaAsync(persona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            await _personaService.DeletePersonaAsync(id);
            return NoContent();
        }
    }
}
