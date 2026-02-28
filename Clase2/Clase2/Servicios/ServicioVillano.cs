using Clase2.Interfaz;
using Clase2.Modelos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Clase2.Servicios
{
    public class ServicioVillano : IServicioVillano
    {
        public async Task<Villano> BuscarPorId(
            SqlConnection connection,
            int id_villano)
        {
            try
            {
                var sql = @"SELECT * FROM villanos WHERE id_villano = @Id";

                return await connection.QueryFirstOrDefaultAsync<Villano>(
                    sql,
                    new { Id = id_villano }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el villano", ex);
            }
        }

        public async Task<IEnumerable<Villano>> ObtenerVillanos(
            SqlConnection connection)
        {
            try
            {
                var sql = @"SELECT * FROM villanos";
                return await connection.QueryAsync<Villano>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los villanos", ex);
            }
        }

        public async Task<Villano> CrearVillano(
            SqlConnection connection,
            Villano villano)
        {
            try
            {
                var sql = @"INSERT INTO villanos (nombre_villano, poder, descripcion)
                          VALUES (@nombre_villano, @poder, @descripcion);
                          SELECT CAST(SCOPE_IDENTITY() AS int);";

                var newId = await connection.QuerySingleAsync<int>(sql, new
                {
                    villano.nombre_villano,
                    villano.poder,
                    villano.descripcion
                });

                villano.id_villano = newId;
                return villano;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el villano", ex);
            }
        }
    }
}
