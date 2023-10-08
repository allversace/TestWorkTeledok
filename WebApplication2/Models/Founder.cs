using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApplication2.DTO;

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

        public FounderDTO ToFounderDTO()
        {
            return new FounderDTO
            {
                INN_founder = INN_founder,
                INN_client = INN_client,
                LastName = LastName,
                FirstName = FirstName,
                Surname = Surname,
                DateAdded = DateAdded,
                DateUpdated = DateUpdated
            };
        }
        
        public static Founder FromFounder(FounderDTO dto)
        {
            return new Founder()
            {
                INN_founder = dto.INN_founder,
                INN_client = dto.INN_client,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Surname = dto.Surname,
                DateAdded = dto.DateAdded,
                DateUpdated = dto.DateUpdated
            };
        }
    }
}
