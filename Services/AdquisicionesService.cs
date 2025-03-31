using Backend.Models;
using Backend.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;
public class AdquisicionesService : IAdquisicionesService
{
    private readonly AdquisicionesContext _context;

    // Inyección de dependencia del contexto de base de datos
    public AdquisicionesService(AdquisicionesContext context)
    {
        _context = context;
    }

    // Obtener todas las adquisiciones
    public IEnumerable<Adquisicion> ObtenerAdquisiciones(FiltrosAdquisicion filtros = null)
    {
        var query = _context.Adquisiciones.AsQueryable();

        // Si hay filtros, aplicarlos
        if (filtros != null)
        {
            if (!string.IsNullOrEmpty(filtros.Presupuesto))
                query = query.Where(a => a.Presupuesto.Contains(filtros.Presupuesto));

            if (!string.IsNullOrEmpty(filtros.Unidad))
                query = query.Where(a => a.Unidad.Contains(filtros.Unidad));

            if (!string.IsNullOrEmpty(filtros.TipoBienServicio))
                query = query.Where(a => a.TipoBienServicio.Contains(filtros.TipoBienServicio));

            if (!string.IsNullOrEmpty(filtros.Proveedor))
                query = query.Where(a => a.Proveedor.Contains(filtros.Proveedor));

            if (filtros.FechaDesde.HasValue)
                query = query.Where(a => a.FechaAdquisicion >= filtros.FechaDesde.Value);

            if (filtros.FechaHasta.HasValue)
                query = query.Where(a => a.FechaAdquisicion <= filtros.FechaHasta.Value);

            // Paginación (si se especifica)
            if (filtros.Pagina > 0 && filtros.ItemsPorPagina > 0)
            {
                query = query
                    .Skip((filtros.Pagina - 1) * filtros.ItemsPorPagina)
                    .Take(filtros.ItemsPorPagina);
            }
        }

        return query
            .OrderByDescending(a => a.FechaAdquisicion)
            .ToList();
    }

    // Obtener una adquisición por su ID
    public Adquisicion? ObtenerAdquisicionPorId(int id)
    {
        return _context.Adquisiciones.AsNoTracking().FirstOrDefault(a => a.Id == id);
    }

    // Agregar una nueva adquisición
    public void AgregarAdquisicion(Adquisicion adquisicion)
    {
        _context.Adquisiciones.Add(adquisicion);
        _context.SaveChanges();  // Persistir en la base de datos
    }

    // Actualizar una adquisición existente
    public void ActualizarAdquisicion(Adquisicion adquisicion)
    {
        _context.Adquisiciones.Update(adquisicion);
        _context.SaveChanges();
    }

    // Eliminar una adquisición
    public void EliminarAdquisicion(Adquisicion adquisicion)
    {
        _context.Adquisiciones.Remove(adquisicion);
        _context.SaveChanges();
    }    
}