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
    public class SuperHeroeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IServicioSuperHeroe _servicioSuperHeroe;

        public SuperHeroeController(IConfiguration config, IServicioSuperHeroe servicioSuperHeroe)
        {
            _config = config;
            _servicioSuperHeroe = servicioSuperHeroe;
        }

        [HttpGet("Obtener Todos")]
        public async Task<ActionResult<List<SuperHeroe>>> ObtenerTodos()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var heroes = _servicioSuperHeroe.ObtenerSuperH(connection);
            return Ok(heroes);
        }

        [HttpGet("ObtenerPorId/{id_superH}")]
        public async Task<ActionResult<List<SuperHeroe>>> ObtenerPorId(int id_superH)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var heroes = _servicioSuperHeroe.BusquedaPorID(connection, id_superH);
            return Ok(heroes);
        }

        [HttpPost("ObtenerPorId")]
        public async Task<ActionResult<List<SuperHeroe>>> BusquedaPostId([FromBody] int id_superH)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var heroes = _servicioSuperHeroe.BusquedaPorID(connection, id_superH);
            return Ok(heroes);
        }
    }
}
