using Clase2.DTOs;
using Clase2.Interfaz;
using Clase2.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Clase2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VillanoController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServicioVillano _servicioVillano;

        public VillanoController(IConfiguration config, IServicioVillano servicioVillano)
        {
            _config = config;
            _servicioVillano = servicioVillano;
        }

        // GET: api/Villano/obtener-todos
        [HttpGet("obtener-todos")]
        public async Task<ActionResult<IEnumerable<Villano>>> ObtenerTodos()
        {
            using var connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            var villanos = await _servicioVillano.ObtenerVillanos(connection);
            return Ok(villanos);
        }

        // GET: api/Villano/obtener-por-id/5
        [HttpGet("obtener-por-id/{id_villano}")]
        public async Task<ActionResult<Villano>> ObtenerPorId(int id_villano)
        {
            using var connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            var villano = await _servicioVillano.BuscarPorId(connection, id_villano);

            if (villano == null)
                return NotFound();

            return Ok(villano);
        }

        // POST: api/Villano/obtener-por-id-body
        [HttpPost("obtener-por-id-body")]
        public async Task<ActionResult<Villano>> ObtenerPorIdBody(
            [FromBody] VillanoBuscarPorIdDto dto)
        {
            using var connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            var villano = await _servicioVillano.BuscarPorId(connection, dto.id_villano);

            if (villano == null)
                return NotFound();

            return Ok(villano);
        }

        // POST: api/Villano/crear-villano
        [HttpPost("crear-villano")]
        public async Task<ActionResult<Villano>> CrearVillano(
            [FromBody] VillanoCreateDto dto)
        {
            using var connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            var villano = new Villano
            {
                nombre_villano = dto.nombre_villano,
                poder = dto.poder,
                descripcion = dto.descripcion
            };

            var creado = await _servicioVillano.CrearVillano(connection, villano);

            return Ok(creado);
        }
    }
}
