using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Data.Repositorio;
using Prueba_Tecnica.Model;

namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductoController : ControllerBase
    {
        private readonly iProductoRepositorio _productoRepositorio;

        public ProductoController(iProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        /* Obtener la informacion de todas los productos */
        [HttpGet]
        public async Task<IActionResult> GetAllProductos()
        {
            return Ok(await _productoRepositorio.GetAllProductos());
        }

        /* Obtener la informacion de el producto por medio del id */
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoDetails(int id)
        {
            return Ok(await _productoRepositorio.Getproductos(id));
        }

        /* Crear el producto */
        [HttpPost]
        public async Task<IActionResult> crearProducto(string nombre, int categorias_id, string descripcion = "na")
        {
            if (nombre == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _productoRepositorio.Insertproductos(nombre, descripcion, categorias_id);

            return Created("created", created);
        }

        /* Actualizar el producto */
        [HttpPut]
        public async Task<IActionResult> actualizarCategoria([FromBody] Productos productos)
        {
            if (productos == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            await _productoRepositorio.Updateproductos(productos);

            return NoContent();
        }

        /* Borrar el producto */
        [HttpDelete]
        public async Task<IActionResult> borrarProducto(int id)
        {
            await _productoRepositorio.Deleteproductos(new Productos { Id = id });

            return NoContent();
        }
    }
}