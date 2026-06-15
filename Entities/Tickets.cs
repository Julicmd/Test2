using System.ComponentModel.DataAnnotations;

namespace Application.Entities;

public class Tickets
{
    public int ScreeningId { get; set; }
    public int CustomerId { get; set; }
    [MaxLength(10)] 
    public string SeatNumber { get; set; } = null!;
    
    public DateTime PurchasedAt { get; set; }
    
    public Customers Customer { get; set; }
    public Screenings Screening { get; set; }
    
}