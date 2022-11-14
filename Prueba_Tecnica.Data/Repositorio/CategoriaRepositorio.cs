using Dapper;
using MySql.Data.MySqlClient;
using Prueba_Tecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Data.Repositorio
{
    public class CategoriaRepositorio : iCategoriaRepositorio
    {

        private readonly MySqlConfiguracion _conntectionString;
        public CategoriaRepositorio(MySqlConfiguracion conntectionString)
        {
            _conntectionString = conntectionString;
        }

        protected MySqlConnection dbConntection()
        {
            return new MySqlConnection(_conntectionString.ConnectionString);
        }

        /* ****** **** */
        public async Task<bool> DeleteCategoria(Categorias categorias)
        {
            var db = dbConntection();

            var sql = @" DELETE FROM categorias WHERE id = @Id";

            var resultado = await db.ExecuteAsync(sql, new { Id = categorias.Id });

            return resultado > 0;
        }

        public async Task<IEnumerable<Categorias>> GetAllCategorias()
        {
            var db = dbConntection();

            var sql = @" SELECT * FROM categorias";

            return await db.QueryAsync<Categorias>(sql, new {});
        }

        public async Task<Categorias> Getcategorias(int id)
        {
            var db = dbConntection();

            var sql = @" SELECT * FROM categorias WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Categorias>(sql, new { Id = id });
        }

        public async Task<bool> InsertCategoria(string nombre, string descripcion)
        {

            var db = dbConntection();

            var sql = @" INSERT INTO categorias(nombre, descripcion) VALUES(@Nombre, @Descripcion) ";

            var resultado = await db.ExecuteAsync(sql, new { nombre, descripcion });

            return resultado > 0;
        }

        public async Task<bool> UpdateCategoria(Categorias categorias /*, int id, string nombre*/ )
        {
            var db = dbConntection();

            var sql = @" UPDATE categorias SET nombre = @Nombre, descripcion = @Descripcion WHERE id = @Id";

            var resultado = await db.ExecuteAsync(sql, new {categorias.Nombre, categorias.Descripcion, categorias.Id });

            return resultado > 0;
        }

    }

    /******** PRODUCTOS **********/
    public class ProductoRepositorio : iProductoRepositorio
    {

        private readonly MySqlConfiguracion _conntectionString;
        public ProductoRepositorio(MySqlConfiguracion conntectionString)
        {
            _conntectionString = conntectionString;
        }

        protected MySqlConnection dbConntection()
        {
            return new MySqlConnection(_conntectionString.ConnectionString);
        }

        /* ****** **** */
        public async Task<bool> Deleteproductos(Productos productos)
        {
            var db = dbConntection();

            var sql = @" DELETE FROM productos WHERE id = @Id";

            var resultado = await db.ExecuteAsync(sql, new { Id = productos.Id });

            return resultado > 0;
        }

        public async Task<IEnumerable<Productos>> GetAllProductos()
        {
            var db = dbConntection();

            //var sql = @" SELECT * FROM productos";
            var sql = @" SELECT p.id, p.nombre, p.descripcion, p.categorias_id, c.nombre AS Nombre_Categoria 
                        FROM productos p, categorias c 
                        WHERE p.categorias_id=c.id";

            return await db.QueryAsync<Productos>(sql, new { });
        }

        public async Task<Productos> Getproductos(int id)
        {
            var db = dbConntection();

            //var sql = @" SELECT * FROM productos WHERE id = @Id";
            var sql = @" SELECT p.id, p.nombre, p.descripcion, p.categorias_id, c.nombre AS Nombre_Categoria 
                        FROM productos p, categorias c 
                        WHERE p.categorias_id=c.id AND p.id = @Id";

            return await db.QueryFirstOrDefaultAsync<Productos>(sql, new { Id = id });
        }

        public async Task<bool> Insertproductos(string nombre, string descripcion, int categorias_id)
        {

            var db = dbConntection();

            var sql = @" INSERT INTO productos(nombre, descripcion, categorias_id) VALUES(@Nombre, @Descripcion, @Categorias_Id) ";

            var resultado = await db.ExecuteAsync(sql, new { nombre, descripcion, categorias_id });

            return resultado > 0;
        }

        public async Task<bool> Updateproductos(Productos productos /*, int id, string nombre*/ )
        {
            var db = dbConntection();

            var sql = @" UPDATE productos SET nombre = @Nombre, descripcion = @Descripcion, categorias_id = Categorias_Id WHERE id = @Id";

            var resultado = await db.ExecuteAsync(sql, new { productos.Nombre, productos.Descripcion, productos.Categorias_Id, productos.Id });

            return resultado > 0;
        }

    }
}
