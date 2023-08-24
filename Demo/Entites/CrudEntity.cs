using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entites
{
    public class CrudEntity
    {
        [Key]
        [Required]
        public string Username { get; set; }
        [Required]
        [Column(TypeName ="varchar")]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
