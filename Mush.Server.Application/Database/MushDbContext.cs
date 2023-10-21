using Microsoft.EntityFrameworkCore;
using Mush.Server.Application.Database.Entities;

namespace Mush.Server.Application.Database;
public class MushDbContext : DbContext
{
    public MushDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Match> Matches { get; set; }
    public DbSet<Pulse> Pulses { get; set; }
}
