namespace Backend.Models
{
    public class Adquisicion
    {
        /// <summary>
        /// Identificador único en base de datos del bien o servicio adquirido
        /// </summary>
        public int? Id { get; set; }

        public string Presupuesto { get; set; } = string.Empty;
        
        public string Unidad { get; set; } = string.Empty;
        
        public string TipoBienServicio { get; set; } = string.Empty;
        
        /// <summary>
        /// Cantidad de bienes o servicio adquiridos
        /// </summary>
        public int Cantidad { get; set; }
        
        /// <summary>
        /// Valor individual de cada bien o servicio adquirido
        /// </summary>
        public decimal ValorUnitario { get; set; }
        
        /// <summary>
        /// Valor total de los bienes o servicios adquiridos
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Fecha en la que se adquirio el bien o servicio
        /// </summary>
        public DateTime FechaAdquisicion { get; set; }

        /// <summary>
        /// Proveedor del bien o servicio adquirido
        /// </summary>
        public string Proveedor { get; set; } = string.Empty;
        
        public string Documentacion { get; set; } = string.Empty;
    }
}
