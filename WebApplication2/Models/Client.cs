using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Client
    {
        [Key]
        public int INN_client { get; set; }

        [Required]
        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        public string Type { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        [InverseProperty("Client")]
        public virtual ICollection<Founder> Founder { get; set; }
    }
}
