// Backend/Controllers/AdquisicionesController.cs
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdquisicionesController : ControllerBase
    {
        private readonly IAdquisicionesService _service;
        private readonly IHistorialService _historialService;

        public AdquisicionesController(
            IAdquisicionesService service,
            IHistorialService historialService)
        {
            _service = service;
            _historialService = historialService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] FiltrosAdquisicion filtros)
        {
            // Versión segura que maneja filtros nulos
            var resultado = filtros == null 
                ? _service.ObtenerAdquisiciones() 
                : _service.ObtenerAdquisiciones(filtros);
            
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var adquisicion = _service.ObtenerAdquisicionPorId(id);
            if (adquisicion == null)
                return NotFound();

            return Ok(adquisicion);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Adquisicion adquisicion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.AgregarAdquisicion(adquisicion);

            // Registrar en historial
            var usuario = User.FindFirst(ClaimTypes.Name)?.Value ?? "Sistema";
            _historialService.RegistrarCambio(adquisicion.Id.Value, "CREATE", adquisicion, usuario);

            return CreatedAtAction(nameof(GetById), new { id = adquisicion.Id }, adquisicion);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Adquisicion adquisicion)
        {
            if (id != adquisicion.Id)
                return BadRequest();

            var existing = _service.ObtenerAdquisicionPorId(id);
            if (existing == null)
                return NotFound();

            _service.ActualizarAdquisicion(adquisicion);

            // Registrar en historial
            var usuario = User.FindFirst(ClaimTypes.Name)?.Value ?? "Sistema";
            _historialService.RegistrarCambio(id, "UPDATE", adquisicion, usuario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var adquisicion = _service.ObtenerAdquisicionPorId(id);
            if (adquisicion == null)
                return NotFound();

            // Registrar en historial antes de eliminar
            var usuario = User.FindFirst(ClaimTypes.Name)?.Value ?? "Sistema";
            _historialService.RegistrarCambio(id, "DELETE", adquisicion, usuario);

            _service.EliminarAdquisicion(adquisicion);
            return NoContent();
        }
    }
}