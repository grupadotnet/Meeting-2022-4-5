using Microsoft.EntityFrameworkCore;
using TutorialASP.Models;

namespace TutorialASP.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; } // Nazwa właściwości odpowiada nazwie tabeli w bazie

    }
}
