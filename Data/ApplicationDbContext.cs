
using Microsoft.EntityFrameworkCore;
using ReadBookWebApp.Models;

namespace ReadBookWebApp.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

    }
}
