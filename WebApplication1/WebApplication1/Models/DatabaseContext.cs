using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers{ get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
