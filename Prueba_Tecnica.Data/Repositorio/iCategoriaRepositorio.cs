using Prueba_Tecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Data.Repositorio
{
    public interface iCategoriaRepositorio
    {
        Task<IEnumerable<Categorias>> GetAllCategorias();

        Task<Categorias> Getcategorias(int id);

        Task<bool> InsertCategoria(string nombre, string descripcion);
        Task<bool> UpdateCategoria(Categorias categorias);
        Task<bool> DeleteCategoria(Categorias categorias);
    }

    public interface iProductoRepositorio
    {
        Task<IEnumerable<Productos>> GetAllProductos();

        Task<Productos> Getproductos(int id);

        Task<bool> Insertproductos(string nombre, string descripcion, int categorias_id);
        Task<bool> Updateproductos(Productos productos);
        Task<bool> Deleteproductos(Productos productos);
    }
}
