using Microsoft.EntityFrameworkCore;
using trabajo.Models;

namespace trabajo.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<Prestamo> Prestamos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Documento)
            .IsUnique();
        
        modelBuilder.Entity<Libro>()
            .HasIndex(l => l.Codigo)
            .IsUnique();
    }
}