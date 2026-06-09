using System.ComponentModel.DataAnnotations;

namespace Application.Entities;

public class Customers
{
    public int CustomerId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    [MaxLength(9)]
    public string Phone { get; set; } = string.Empty;
    
    public ICollection<Tickets> Tickets { get; set; } = new List<Tickets>();
}