using JanBatchCodeFirstApproachImpl.Models;
using Microsoft.EntityFrameworkCore;

namespace JanBatchCodeFirstApproachImpl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Emp> Emps { get; set; }
    }

}
