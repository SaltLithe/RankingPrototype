using Microsoft.EntityFrameworkCore;
using RankingCore.Persistence.Models;

namespace RankingCore.Persistence.Contexts;

public partial class RankingContext : DbContext
{
    public RankingContext()
    {
    }

    public RankingContext(DbContextOptions<RankingContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=C:\\sqlite\\Ranking.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Player> Players { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<Account> Accounts { get; set; }
}
