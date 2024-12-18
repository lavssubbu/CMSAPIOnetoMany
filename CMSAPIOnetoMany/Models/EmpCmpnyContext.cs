using Microsoft.EntityFrameworkCore;
namespace CMSAPIOnetoMany.Models
{
    public class EmpCmpnyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companiess { get; set; }

        public EmpCmpnyContext(DbContextOptions<EmpCmpnyContext> options) : base(options) { }
    }
}
