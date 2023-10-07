using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.DTO;

namespace WebApplication2.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly TeledokDataContext _context;

        public ClientController(TeledokDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClients()
        {
            return await _context.ClientDTO.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> AddClient(ClientDTO newClient)
        {
            newClient.DateAdded = DateTime.UtcNow;
            newClient.DateUpdated = DateTime.UtcNow;
            _context.ClientDTO.Add(newClient);
            await _context.SaveChangesAsync();

            return Ok(newClient);
        }
    }
}
