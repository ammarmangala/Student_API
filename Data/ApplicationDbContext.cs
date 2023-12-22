using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Template_Web_API.Entities;

namespace Template_Web_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
