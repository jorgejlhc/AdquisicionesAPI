using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class AdquisicionesContext : DbContext
    {
        public AdquisicionesContext(DbContextOptions<AdquisicionesContext> options) : base(options)
        {
        }

        public DbSet<Adquisicion> Adquisiciones { get; set; }
        public DbSet<HistorialCambio> HistorialCambios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistorialCambio>()
                .HasOne<Adquisicion>()  
                .WithMany()
                .HasForeignKey(h => h.AdquisicionId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}