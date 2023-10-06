using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private TeledokDataContext _context;

        public ClientController(TeledokDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetClient")]
        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Client.ToListAsync();
        }

        [HttpPost]
        [Route("AddClient")]
        public async Task<Client> AddClient(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
