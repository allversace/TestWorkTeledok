using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("GetClients")]
        public IActionResult GetAllClients()
        {
            var clients = _clientService.GetAllClients();
            var clientAPIs = clients.Select(_clientService.GetClientAPI).ToList();
            return Ok(clientAPIs);
        }
    }
}
