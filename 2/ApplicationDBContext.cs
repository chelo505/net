using Microsoft.EntityFrameworkCore;
using net2_quiz2_დავით_ჭელიძეwebapi.Models;

namespace net2_quiz2_დავით_ჭელიძეwebapi
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }

}
