namespace WebApplication2.DTO;

public class FounderDTO
{
    public int INN_founder { get; set; }

    public int INN_client { get; set; }
    
    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Surname { get; set; }

    public DateTime DateAdded { get; set; } = DateTime.UtcNow;

    public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
}