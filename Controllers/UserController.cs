using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Stuffed.Models;
using Stuffed.Data;

namespace Stuffed.Controllers;

public class UserController : Controller
{
    private readonly DatabaseContext _context;
    private readonly ILogger<HomeController> _logger;

    public UserController(ILogger<HomeController> logger,
     DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Create()
    {
        return View("Create");
    }
    public IActionResult List()
    {
        var listUser = _context.Users.OrderBy(s => s.ID).ToList();
        return View("List", listUser);
    }

    public IActionResult CreateUser(UserModel objcreate)
    {
        if (ModelState.IsValid)
        {
            objcreate.Mensaje = "El Usuario a sido Registrado con Éxito";

            _context.Add(objcreate);
            _context.SaveChanges();

            return View("Create", objcreate);
        }
        return View("Create");
    }

    public IActionResult Search(string search)
    {
        var ListarLibro = from l in _context.Users select l;
        if (!String.IsNullOrEmpty(search))
        {
            ListarLibro = ListarLibro
                          .Where(l => l.last_name.Contains(search))
                          .OrderBy(l => l.last_name);
        }
        return View("List", ListarLibro);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var create = _context.Users.Find(id);
        if (create == null)
        {
            return NotFound();
        }
        return View(create);
    }

    [HttpPost]
    public IActionResult Edit(int id, UserModel user)
    {
        if (ModelState.IsValid)
        {
            _context.Update(user);
            _context.SaveChanges();
            user.Mensaje = "El Usuario a sido modificado con Éxito";
        }
        return View(user);
    }

    public IActionResult Delete(int? id)
    {
        var create = _context.Users.Find(id);
        _context.Users.Remove(create);
        _context.SaveChanges();
        return RedirectToAction(nameof(List));
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}