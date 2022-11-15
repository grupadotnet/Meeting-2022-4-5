using Microsoft.EntityFrameworkCore;
using TutorialASP.Models;

namespace TutorialASP.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // Nazwa właściwości odpowiada nazwie tabeli w bazie

    }
}
