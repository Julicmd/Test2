using Application.Data;
using Application.DTOs;
using Application.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/screenings")]
public class SreeningController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public SreeningController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet("{id}:int")]
    public async Task<ActionResult> GetScreening(int id)
    {
        var screening =  _context.Screenings.Where(sc => sc.ScreeningId == id)
            .Select(s => new ScreeningDto
            {
                scid = s.ScreeningId,
                screeningDate = s.ScreeningDate,
                ticketPrice = s.TicketPrice,
            });


        if (screening is null)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    
    [HttpPost("{id}/tickets")] 
    public async Task<ActionResult> PostScreening([FromBody] TicektDto ticket)
    {
        
        //var ticket = await.
        

        return NoContent();
    }
    
}