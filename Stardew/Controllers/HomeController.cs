using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Stardew.Models;
using Stardew.Services;

namespace Stardew.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IColheService _colheService;
    public HomeController(ILogger<HomeController> logger, IColheService colheService)
    {
        _logger = logger;
        _colheService = colheService;
    }

    public IActionResult Index(string tipo)
    {
        var colher = _colheService.GetStardewDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(colher);
    }

    public IActionResult Details(int Numero)
    {
        var colheita = _colheService.GetDetailedColheita(Numero);
        return View(colheita);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}