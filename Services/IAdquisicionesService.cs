using Backend.Models;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface IAdquisicionesService
    {
        // Obtener todas las adquisiciones
        IEnumerable<Adquisicion> ObtenerAdquisiciones(FiltrosAdquisicion filtros = null);

        // Obtener una adquisición por ID
        Adquisicion? ObtenerAdquisicionPorId(int id);

        // Agregar una nueva adquisición
        void AgregarAdquisicion(Adquisicion adquisicion);

        // Actualizar una adquisición existente
        void ActualizarAdquisicion(Adquisicion adquisicion);

        // Eliminar una adquisición
        void EliminarAdquisicion(Adquisicion adquisicion);
    }
}
