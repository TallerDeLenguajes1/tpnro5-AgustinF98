using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP5.Entidades
{
    public class Helper
    {
        public static Tareas BuscarPorID(int _id, List<Tareas> ListaTareas)
        {
            foreach(var Tarea in ListaTareas)
            {
                if (Tarea.Id == _id)
                {
                    return Tarea;
                }
            }
            return null;
        }
    }
}
