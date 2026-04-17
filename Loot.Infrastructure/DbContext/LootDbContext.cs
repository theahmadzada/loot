using Loot.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Loot.Infrastructure.DbContext;

public class LootDbContext(DbContextOptions<LootDbContext> options) : IdentityDbContext<User, Role, Guid>(options)
{
    DbSet<Board> Boards { get; set; }
    DbSet<Column> Columns { get; set; }
    DbSet<TaskItem>  Tasks { get; set; }
    DbSet<BoardMember> Members { get; set; }
}

public class LootDbContextFactory : IDesignTimeDbContextFactory<LootDbContext>
{
    public LootDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LootDbContext>();
        
        optionsBuilder.UseNpgsql("Host=localhost;Port=50291;Username=postgres;Password=+UhrnR0N2.}(}Dz(y}4Zyz\n\n");

        return new LootDbContext(optionsBuilder.Options);
    }
}