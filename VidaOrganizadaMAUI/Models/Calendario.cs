using SQLite;
using System;

namespace VidaOrganizadaMAUI.Models
{
    [Table("Eventos")]
    public class Evento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime FechaEvento { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
