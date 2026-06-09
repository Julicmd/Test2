using Application.Data;
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
    
    
}