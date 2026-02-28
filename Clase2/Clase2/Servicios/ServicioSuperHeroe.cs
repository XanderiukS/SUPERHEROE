using Clase2.Interfaz;
using Clase2.Modelos;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System;

namespace Clase2.Servicios
{
    public class ServicioSuperHeroe : IServicioSuperHeroe
    {
        public IEnumerable<SuperHeroe> BusquedaPorID(SqlConnection connection, int id_superH)
        {
            try
            {
                var Resultado = connection.QueryAsync<SuperHeroe>("SELECT * FROM SUPERHEROE where id_heroe = " + id_superH);
                return Resultado.Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los superheroes ", ex);
            }
        }

        public IEnumerable<SuperHeroe> ObtenerSuperH(SqlConnection connection)
        {
            try
            {
                var resultado = connection.QueryAsync<SuperHeroe>("select * from superheroe");
                return resultado.Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los superheroes ", ex);
            }
        }
    }
}
