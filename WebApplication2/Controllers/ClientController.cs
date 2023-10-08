using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

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
    [Route("GetClients")]
    public ActionResult<IEnumerable<ClientDTO>> GetClients()
    {
        var clients = _context.Client.ToList();
        var clientDtos = clients.Select(client => client.ToClientDPO()).ToList();
        return Ok(clientDtos);
    }

    [HttpPost]
    [Route("CreateClient")]
    public IActionResult CreateClient([FromBody] ClientDTO createClientDto)
    {
        if (createClientDto == null)
        {
            return BadRequest("Invalid client data");
        }

        var client = Client.FromClient(createClientDto);
        _context.Client.Add(client);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetClients), new { id = client.INN_client }, client.ToClientDPO());
    }
}