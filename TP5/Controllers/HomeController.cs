using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
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
        private static List<Tareas> listaTareas = new List<Tareas>();
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
            listaTareas.Clear();

            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), @"BDatos\BDtp5.db");
            var conection = new SQLiteConnection(cadena);
            conection.Open();

            var command = conection.CreateCommand();
            command.CommandText = "SELECT * FROM Tareas";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Tareas tarea = new Tareas();
                tarea.Id = Convert.ToInt32(reader["IDtarea"]);
                tarea.Descripcion = Convert.ToString(reader["Descripcion"]);
                tarea.Duracion = Convert.ToInt32(reader["Duracion"]);
                tarea.Estado = Convert.ToString(reader["Estado"]);
                listaTareas.Add(tarea);
            }

            conection.Close();

            return View(listaTareas);
        }

        public IActionResult AltaTarea()
        {
            return View(new Tareas());
        }

        [HttpPost]
        public IActionResult CrearTarea(string Descripcion, int Duracion, string Estado)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), @"BDatos\BDtp5.db");
            var conection = new SQLiteConnection(cadena);
            conection.Open();

            var command = conection.CreateCommand();
            command.CommandText = "INSERT INTO Tareas(Descripcion, Duracion, Estado) VALUES (@Descripcion, @Duracion, @Estado)";
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
            command.Parameters.AddWithValue("@Duracion", Duracion);
            command.Parameters.AddWithValue("@Estado", Estado);
            command.ExecuteNonQuery();

            conection.Close();

            return Redirect("/Home/MostrarTareas");
        }

        public IActionResult BajaTarea(int ID)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), @"BDatos\BDtp5.db");
            var conection = new SQLiteConnection(cadena);
            conection.Open();

            var command = conection.CreateCommand();
            command.CommandText = "DELETE FROM Tareas WHERE IDtarea = @ID";
            command.Parameters.AddWithValue("@ID", ID);
            command.ExecuteNonQuery();

            conection.Close();

            return Redirect("/Home/MostrarTareas");
        }

        public IActionResult Modificacion(int ID)
        {
            Tareas tareaAux = new Tareas();
            tareaAux = Helper.BuscarPorID(ID, listaTareas);

            return View(tareaAux);
        }

        public IActionResult ModificacionTarea(int ID, string Descripcion, int Duracion, string Estado)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), @"BDatos\BDtp5.db");
            var conection = new SQLiteConnection(cadena);
            conection.Open();

            var command = conection.CreateCommand();
            command.CommandText = "UPDATE Tareas SET Descripcion = @Descripcion, Duracion = @Duracion, Estado = @Estado WHERE IDtarea = @ID";
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
            command.Parameters.AddWithValue("@Duracion", Duracion);
            command.Parameters.AddWithValue("@Estado", Estado);
            command.ExecuteNonQuery();
            
            conection.Close();

            return Redirect("/Home/MostrarTareas");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
