using System.ComponentModel.DataAnnotations;

namespace Application.Entities;

public class Movies
{
    public int MovieId { get; set; }
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public string Genre { get; set; } = string.Empty;
    
    public ICollection<Screenings> Screenings { get; set; } = new List<Screenings>();
}