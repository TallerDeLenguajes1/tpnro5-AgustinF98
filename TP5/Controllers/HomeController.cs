using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP5.Entidades;
using TP5.Models;

namespace TP5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<Tareas> tareas = new List<Tareas>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MostrarTareas()
        {
            return View();
        }

        public IActionResult AltaTarea()
        {
            return View(new Tareas());
        }

        [HttpPost]
        public IActionResult CrearTarea(string _descripcion, int _duracion)
        {
            Tareas tarea = new Tareas();
            tarea.Descripcion = _descripcion;
            tarea.Duracion = _duracion;

            tareas.Add(tarea);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
