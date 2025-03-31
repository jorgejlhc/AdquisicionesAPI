namespace Backend.Models
{
    public class ResultadoPaginado<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Pagina { get; set; }
        public int ItemsPorPagina { get; set; }
    }
}