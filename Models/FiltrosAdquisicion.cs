namespace Backend.Models
{
    public class FiltrosAdquisicion
    {
        public string? Presupuesto { get; set; }
        public string? Unidad { get; set; }
        public string? TipoBienServicio { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string? Proveedor { get; set; }
        public int Pagina { get; set; } = 1;
        public int ItemsPorPagina { get; set; } = 10;
    }
}