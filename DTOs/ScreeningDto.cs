using System.Runtime.InteropServices;

namespace Application.DTOs;

public class ScreeningDto
{
    public int scid { get; set; }

    public class MoviesDto
    {
        public string title { get; set; }
        public string director { get; set; }
        public int durationMinutes { get; set; }
        public string genre { get; set; }
    }
    public class HallsDto
    {
        public string name { get; set; }
        public int capacity { get; set; }
        public string type { get; set; }
    }
    
    public DateTime screeningDate { get; set; }
    public decimal ticketPrice { get; set; }
    public int availableSeats { get; set; }
    
    public List<TicketsDto> tickets { get; set; }

    public class TicketsDto
    {
        public string seatNumber { get; set; }
        public DateTime purchasedAt { get; set; }
    }
    
    public class CustomersDto
    {
       public int firstName { get; set; }
       public int lastName { get; set; }
       public string email { get; set; }
       public string phone { get; set; }
    }
    
}