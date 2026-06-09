using System.ComponentModel.DataAnnotations;

namespace Application.Entities;

public class Halls
{
    public int HallId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }= string.Empty;
    public int Capacity { get; set; }
    [MaxLength(50)]
    public string Type { get; set; }=string.Empty;
    
    
    public ICollection<Screenings> Screenings { get; set; } = new List<Screenings>();
}