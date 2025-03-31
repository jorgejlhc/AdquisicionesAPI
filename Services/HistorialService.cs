using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Models;
using Backend.Data;

namespace Backend.Services
{
    public class HistorialService : IHistorialService
    {
        private readonly AdquisicionesContext _context;

        public HistorialService(AdquisicionesContext context)
        {
            _context = context;
        }

        public void RegistrarCambio(int adquisicionId, string accion, Adquisicion datos, string usuario)
        {
            var historial = new HistorialCambio
            {
                AdquisicionId = adquisicionId,
                Accion = accion,
                Detalles = System.Text.Json.JsonSerializer.Serialize(datos),
                Usuario = usuario,
                FechaCambio = DateTime.UtcNow
            };

            _context.HistorialCambios.Add(historial);
            _context.SaveChanges();
        }

        public IEnumerable<HistorialCambio> ObtenerHistorial(int adquisicionId)
        {
            return _context.HistorialCambios
                .Where(h => h.AdquisicionId == adquisicionId)
                .OrderByDescending(h => h.FechaCambio)
                .ToList();
        }
    }
}