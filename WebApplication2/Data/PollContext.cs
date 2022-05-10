using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Entities;

namespace WebApplication2.Data;

public class PollContext : DbContext
{
    public DbSet<Poll> Polls { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Vote> Votes { get; set; }
    public DbSet<User> Users { get; set; }

    public PollContext(DbContextOptions<PollContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Poll>()
            .HasMany(x => x.Answers)
            .WithOne(x => x.Poll)
            .HasForeignKey(x => x.PollId);

        modelBuilder.Entity<Poll>()
            .HasMany(x => x.Votes)
            .WithOne(x => x.Poll)
            .HasForeignKey(x => x.PollId);

        modelBuilder.Entity<Vote>()
            .HasIndex(x => new { x.UserId, x.PollId })
            .IsUnique();
    }
}