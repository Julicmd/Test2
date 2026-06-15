namespace Application.DTOs;

public class TicketResponseDto
{
    public string SeatNumber { get; set; }
    public DateTime PurchasedAt { get; set; }
    
    public CustomerDto Customer { get; set; }

    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}