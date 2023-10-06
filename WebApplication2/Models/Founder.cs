using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class Founder
    {
        [Key]
        public int INN_founder { get; set; }

        [Required]
        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string Surname { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;


        [ForeignKey("Client")]
        public int INN_client { get; set; }

        public virtual Client Client { get; set; }

    }
}
