using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ModelsAPI;

namespace WebApplication2.Services
{
    public class ClientService
    {
        private readonly TeledokDataContext _context;

        public ClientService(TeledokDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Client.ToList();
        }

        public ClientAPI GetClientAPI(Client client)
        {
            return new ClientAPI
            {
                INN_client = client.INN_client,
                Name = client.Name,
                Type = client.Type,
                DateAdded = client.DateAdded,
                DateUpdated = client.DateUpdated
            };
        }
    }
}
