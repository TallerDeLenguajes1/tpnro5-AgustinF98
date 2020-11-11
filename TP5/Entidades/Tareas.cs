using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP5.Entidades
{
    public class Tareas
    {
        private int id;
        private string descripcion;
        private int duracion;
        private string estado;

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "Tiene que definir una descripcion")]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        
        [Required(ErrorMessage = "Tiene que definir una duracion")]
        public int Duracion { get => duracion; set => duracion = value; }

        [Required(ErrorMessage = "Tiene que definir un estado de la tarea")]
        public string Estado { get => estado; set => estado = value; }

        public Tareas()
        {
            Id = 0;
            Descripcion = "";
            Duracion = 0;
            Estado = "";
        }

        public Tareas(int _id, string _descripcion, int _duracion, string _estado)
        {
            Id = _id;
            Descripcion = _descripcion;
            Duracion = _duracion;
            Estado = _estado;
        }
    }
}
