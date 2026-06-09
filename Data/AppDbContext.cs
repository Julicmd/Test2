using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public class AppDbContext : DbContext
{
    public DbSet<Halls> Halls { get; set; }
    public DbSet<Screenings> Screenings { get; set; }
    public DbSet<Movies> Movies { get; set; }
    public DbSet<Tickets> Tickets { get; set; }
    public DbSet<Customers> Customers { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Halls>().HasKey(h => h.HallId);
        modelBuilder.Entity<Screenings>().HasKey(sc => sc.ScreeningId);
        modelBuilder.Entity<Movies>().HasKey(sc => sc.MovieId);
        modelBuilder.Entity<Tickets>().HasKey(t => new { t.ScreeningId, t.CustomerId });
        modelBuilder.Entity<Customers>().HasKey(c => c.CustomerId);

    }
    
}