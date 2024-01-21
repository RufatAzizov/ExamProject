using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Contexts
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Fruit> Fruits { get; set; }
    }
}
