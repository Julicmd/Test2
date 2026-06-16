using System.Runtime.InteropServices;

namespace Application.DTOs;

public class ScreeningDto
{
    public int ScreeningId { get; set; }
    public MovieDto Movie { get; set; }  // jeigu yra tokie {} reiskia bus klase
    public HallDto Hall { get; set; }
    
    public DateTime ScreenDate { get; set; }
    public decimal TicketPrice { get; set; }
    public int? AvailableSeats { get; set; }
    public List<TicketResponseDto> Tickets { get; set; } // ir jeigu yra [] tada bus collection ir dar jeigu toliau {} dar tokie tada bus atskiras dto 
    
    
    public class MovieDto // va toks va 
    {
        public string Title { get; set; }
        public string Director { get; set; } 
        public int Duration { get; set; }
        public string Genre { get; set; }
        
    }

    public class HallDto // ir kaip cia 
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        
    }
    
    





}