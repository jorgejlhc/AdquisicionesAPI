using System.Collections.Generic;
using Backend.Models;

namespace Backend.Services
{
    public interface IHistorialService
    {
        void RegistrarCambio(int adquisicionId, string accion, Adquisicion datos, string usuario);
        IEnumerable<HistorialCambio> ObtenerHistorial(int adquisicionId);
    }
}