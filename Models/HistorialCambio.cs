using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class HistorialCambio
    {
        public int Id { get; set; }
        public int AdquisicionId { get; set; }
        public string Accion { get; set; } // "CREATE", "UPDATE", "DELETE"
        public string Detalles { get; set; } // JSON con los cambios
        public DateTime FechaCambio { get; set; } = DateTime.UtcNow;
        public string Usuario { get; set; } // Nombre o ID del usuario        
    }
}