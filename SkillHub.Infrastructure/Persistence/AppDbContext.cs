using Microsoft.EntityFrameworkCore;
using SkillHub.Domain.Entities;


namespace SkillHub.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
    }
}
