using Clase2.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Clase2.Interfaz
{
    public interface IServicioSuperHeroe
    {
        public IEnumerable<SuperHeroe> ObtenerSuperH(SqlConnection connection);
        public IEnumerable<SuperHeroe> BusquedaPorID(SqlConnection connection, int id_superH);
    }
}
