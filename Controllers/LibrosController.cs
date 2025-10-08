using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trabajo.Data;
using trabajo.Models;

namespace trabajo.Controllers;

public class LibrosController: Controller
{
    private readonly AppDbContext _appDbContext;

    public LibrosController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IActionResult> Index()
    {
        List<Libro> lista = await _appDbContext.Libros.ToListAsync();
        return View(lista);
    }

    public IActionResult Agregar()
    {
        return View();
    }

    public async Task<IActionResult> Nuevo(Libro libro)
    {
        await _appDbContext.Libros.AddAsync(libro);
        await _appDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}