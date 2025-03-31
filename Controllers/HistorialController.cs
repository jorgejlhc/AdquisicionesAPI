using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/adquisiciones/{adquisicionId}/historial")]
    public class HistorialController : ControllerBase
    {
        private readonly IHistorialService _historialService;

        public HistorialController(IHistorialService historialService)
        {
            _historialService = historialService;
        }

        [HttpGet]
        public IActionResult GetHistorial(int adquisicionId)
        {
            var historial = _historialService.ObtenerHistorial(adquisicionId);
            return Ok(historial);
        }
    }
}