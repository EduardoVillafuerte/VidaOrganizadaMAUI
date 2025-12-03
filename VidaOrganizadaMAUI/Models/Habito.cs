using SQLite;
using System;

namespace VidaOrganizadaMAUI.Models
{
    [Table("Habitos")]
    public class Habito
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Frecuencia { get; set; } // e.g. Diario, Semanal

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
