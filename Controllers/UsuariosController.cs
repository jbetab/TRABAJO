using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trabajo.Data;
using trabajo.Models;

namespace trabajo.Controllers;

public class UsuariosController : Controller
{
    private readonly AppDbContext _appDbContext;

    public UsuariosController(AppDbContext appContext)
    {
        _appDbContext = appContext;
    }
    public async Task<IActionResult> Index()
    {
        List<User> lista = await _appDbContext.Users.ToListAsync();
        return View(lista);
    }
    
    public IActionResult Agregar()
    {
        return View();
    }
    
    public async Task<IActionResult> nuevo(User user)
    {
        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Editar(int Id)
    {
        User user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == Id);
        return View(user);
    }
    
    public async Task<IActionResult> Editar(User user)
    { 
        _appDbContext.Users.Update(user);
        await _appDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}