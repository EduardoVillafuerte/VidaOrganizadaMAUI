using SQLite;
using System;

namespace VidaOrganizadaMAUI.Models
{
    [Table("Notas")]
    public class Nota
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Contenido { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
