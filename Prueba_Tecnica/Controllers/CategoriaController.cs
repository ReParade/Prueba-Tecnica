using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Data.Repositorio;
using Prueba_Tecnica.Model;

namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriaController : ControllerBase
    {
        private readonly iCategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(iCategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        /* Obtener la informacion de todas las categorias */
        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            return Ok(await _categoriaRepositorio.GetAllCategorias());
        }

        /* Obtener la informacion de la categoria por medio del id */
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriasDetails(int id)
        {
            return Ok(await _categoriaRepositorio.Getcategorias(id));
        }

        /* Crear la categoria */
        [HttpPost]
        public async Task<IActionResult> crearCategoria( string nombre, string descripcion = "na")
        {
            if (nombre == null)
                return BadRequest();
                
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _categoriaRepositorio.InsertCategoria(nombre, descripcion);

            return Created("created", created);
        }

        /* Actualizar la categoria */
        [HttpPut]
        public async Task<IActionResult> actualizarCategoria([FromBody] Categorias categorias /*, int id, string nombre*/ )
        {
            if (categorias == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            await _categoriaRepositorio.UpdateCategoria(categorias /*, id, nombre*/ );

            return NoContent();
        }

        /* Borrar la categoria */
        [HttpDelete]
        public async Task<IActionResult> borrarCategoria(int id)
        {
            await _categoriaRepositorio.DeleteCategoria(new Categorias { Id = id });

            return NoContent();
        }
    }
}
