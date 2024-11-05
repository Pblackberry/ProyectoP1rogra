using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoP1rogra.Models
{
    public class Membresias
    {
        [Key]
        public int IDcliente { get; set; }
        [MaxLength(10)]
        [MinLength(10)]
        public string cedula { get; set; }
        public string nombre { get; set; }
        
        public string membresia { get; set; }
        public DateTime caducidad { get; set; }
    }
}
