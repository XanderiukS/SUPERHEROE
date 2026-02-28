using Clase2.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Clase2.Interfaz
{
    public interface IServicioVillano
    {
        Task<Villano> BuscarPorId(SqlConnection connection, int id_villano);
        Task<IEnumerable<Villano>> ObtenerVillanos(SqlConnection connection);
        Task<Villano> CrearVillano(SqlConnection connection, Villano villano);
    }
}
