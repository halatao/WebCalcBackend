using Microsoft.EntityFrameworkCore;
using WebCalc.Models;

namespace WebCalc.Data;

public class WebCalcContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Example>? Examples { get; set; }

    public WebCalcContext(IConfiguration configuration)
    {
        _configuration = configuration;
        //base.Database.EnsureDeleted();
        //base.Database.EnsureCreated();
    }

    public WebCalcContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Example>(entity =>
        {
            entity.HasKey(q => q.Id);
            entity.Property(q => q.Id).ValueGeneratedOnAdd();

            entity.Property(q => q.FirstNumber).IsRequired();
            entity.Property(q => q.SecondNumber).IsRequired();
            entity.Property(q => q.Result).IsRequired();
            entity.Property(q => q.Operation).IsRequired();
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("WebCalcDb"));
    }
}