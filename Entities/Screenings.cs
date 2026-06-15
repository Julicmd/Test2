namespace Application.Entities;

public class Screenings
{
    public int ScreeningId { get; set; }
    public int HallId { get; set; } // cia sukuriam id jo fk
    public int MovieId { get; set; }
    public DateTime ScreeningDate { get; set; }
    public decimal TicketPrice { get; set; }

    public Halls Hall { get; set; }   // o cia mes suskuriam susjungima nav FK
    public Movies Movie { get; set; } // sitie reikalingi nes cia yra id kitos lenteles 
    
    public int? AvailableSeats { get; set; }
    
    public ICollection<Tickets> Tickets { get; set; } = new List<Tickets>();
    
    
}