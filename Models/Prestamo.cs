namespace trabajo.Models;

public class Prestamo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User Usuario { get; set; }
    public int LibroId { get; set; }
    public Libro Libro { get; set; }
    public DateTime FechaPrestamo { get; set; } = DateTime.Now;
    public DateTime FechaDevolucion { get; set; }
    public bool Devuelto { get; set; } = false;
}  