using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.DTO;

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
        
        public ClientDTO ToClientDPO()
        {
            return new ClientDTO
            {
                INN_client = this.INN_client,
                Name = this.Name,
                Type = this.Type,
                DateAdded = this.DateAdded,
                DateUpdated = this.DateUpdated
            };
        }
        
        public static Client FromClient(ClientDTO dto)
        {
            return new Client
            {
                INN_client = dto.INN_client,
                Name = dto.Name,
                Type = dto.Type,
                DateAdded = dto.DateAdded,
                DateUpdated = dto.DateUpdated
            };
        }
    }
}
