using Loot.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Loot.Infrastructure.DbContext;

public class LootDbContext(DbContextOptions options) : IdentityDbContext<User, Role, Guid>(options)
{
    DbSet<Board> Boards { get; set; }
    DbSet<Column> Columns { get; set; }
    DbSet<TaskItem>  Tasks { get; set; }
}