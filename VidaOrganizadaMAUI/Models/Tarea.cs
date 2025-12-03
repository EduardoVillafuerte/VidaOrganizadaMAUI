using SQLite;
using System;

namespace VidaOrganizadaMAUI.Models
{
    [Table("Tareas")]
    public class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public bool Completada { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
