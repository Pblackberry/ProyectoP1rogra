using System.ComponentModel.DataAnnotations;

namespace ProyectoP1rogra.Models
{
    public class InicioSesion
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Contrasena { get; set; }
    }
}
