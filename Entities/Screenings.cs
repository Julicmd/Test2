namespace Application.Entities;

public class Screenings
{
    public int ScreeningId { get; set; }
    public int HallId { get; set; }
    public int MovieId { get; set; }
    public DateTime ScreeningDate { get; set; }
    public decimal TicketPrice { get; set; }
    
    public int? AvailableSeats { get; set; }
    
    public ICollection<Tickets> Tickets { get; set; } = new List<Tickets>();
    
    
}