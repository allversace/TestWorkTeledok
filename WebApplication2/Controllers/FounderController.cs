using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

[Route("api/Founder")]
[ApiController]
public class FounderController : ControllerBase
{
    private readonly TeledokDataContext _context;

    public FounderController(TeledokDataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("GetFounders")]
    public ActionResult<IEnumerable<FounderDTO>> GetFounders()
    {
        var founders = _context.Founder.ToList();
        var founderDtos = founders.Select(founder => founder.ToFounderDTO()).ToList();
        return Ok(founderDtos);
    }
    
    [HttpPost]
    [Route("CreateFounders")]
    public IActionResult CreateFounder([FromBody] FounderDTO createFounderDto)
    {
        if (createFounderDto == null)
        {
            return BadRequest("Invalid founder data");
        }

        var founder = Founder.FromFounder(createFounderDto);
        _context.Founder.Add(founder);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetFounders), new { id = founder.INN_founder }, founder.ToFounderDTO());
    }
}