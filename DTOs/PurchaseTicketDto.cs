using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class PurchaseTicketDto
{
    [Required]
    public string FirtName { get; set; }=string.Empty;
    [Required]
    public string LastName { get; set; }=string.Empty;
    
    public string Email { get; set; }=string.Empty;
    [Required]
    public string Phone { get; set; }=string.Empty;
    [Required]
    public string SeatNumber { get; set; }=string.Empty;
}