using SQLite;

namespace VidaOrganizadaMAUI.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Usuario { get; set; }

        [MaxLength(100)]
        public string? Contrasena { get; set; }

        public string? Nombre { get; set; }
    }
}
