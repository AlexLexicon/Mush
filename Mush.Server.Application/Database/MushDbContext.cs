using Microsoft.EntityFrameworkCore;

namespace Mush.Server.Application.Database;
public class MushDbContext : DbContext
{
    public MushDbContext(DbContextOptions options) : base(options)
    {
    }
}
