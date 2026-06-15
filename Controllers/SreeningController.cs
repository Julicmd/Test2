using Application.Data;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Entities;


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


    [HttpGet]
    public async Task<ActionResult> GetScreening([FromQuery] DateOnly? date)
    {
        var query = _context.Screenings
            .Include(s=> s.Movie)
            .Include(s => s.Hall)
            .Include(s=> s.Tickets)
            .ThenInclude(t=>t.Customer)
            .AsQueryable();

        if (date.HasValue)
        {
            query = query.Where(s=> DateOnly.FromDateTime(s.ScreeningDate).Equals(date.Value));
        }

        var result = await query.Select(s => new ScreeningDto
        {
            ScreeningId = s.ScreeningId,
            ScreenDate = s.ScreeningDate,
            TicketPrice = s.TicketPrice,
            AvailableSeats = s.AvailableSeats,
            Movie = new ScreeningDto.MovieDto
            {
                Title = s.Movie.Title,
                Director = s.Movie.Director,
                Duration = s.Movie.DurationMinutes,
                Genre = s.Movie.Genre,
            },
            Hall = new ScreeningDto.HallDto
            {
                Name = s.Hall.Name,
                Capacity = s.Hall.Capacity,
                Type = s.Hall.Type,
            },
            Tickects = s.Tickets.Select(t=> new TicketResponseDto
            {
                SeatNumber = t.SeatNumber,
                PurchasedAt = t.PurchasedAt,
                Customer = new TicketResponseDto.CustomerDto
                {
                    FirstName = t.Customer.FirstName,
                    LastName = t.Customer.LastName,
                    Email = t.Customer.Email,
                    Phone = t.Customer.Phone,
                }
            }).ToList()
        }).ToListAsync();
        
        
        return Ok(result);
    }
    
    
    [HttpPost("{id}/tickets")] 
    public async Task<ActionResult> PostScreening([FromBody] PurchaseTicketDto dto, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await using var transaction = await _context.Database.BeginTransactionAsync();

        var screening = await _context.Screenings.FindAsync(id);

        if (screening == null)
        {
            return NotFound("Screening with this id  not found");
        }

        if (screening.ScreeningDate < DateTime.Now)
        {
            return BadRequest("Cannot purchase a ticket past screening");
        }

        var customer = new Customers
        {
            FirstName = dto.FirtName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
        };
        
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();

        var ticket = new Tickets
        {
            ScreeningId = id, // is arguments nes mes cia perkamm bilieta tai reikia 
            CustomerId =  customer.CustomerId,
            SeatNumber = dto.SeatNumber,
            PurchasedAt = DateTime.Now,
        };
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
        
        await transaction.CommitAsync();
        
        return Created();
    }
    
}