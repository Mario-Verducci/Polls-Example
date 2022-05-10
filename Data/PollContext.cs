using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class PollContext : DbContext
{
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<Poll> Polls { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vote> Votes { get; set; }

    public PollContext() { }

    public PollContext(DbContextOptions<PollContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
    }
}