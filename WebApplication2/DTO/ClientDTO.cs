namespace WebApplication2.DTO;

public class ClientDTO
{
    public int INN_client { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
}