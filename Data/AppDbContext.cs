using Microsoft.EntityFrameworkCore;
using KutuphaneYonetim.Models;

namespace KutuphaneYonetim.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();
    }
}
