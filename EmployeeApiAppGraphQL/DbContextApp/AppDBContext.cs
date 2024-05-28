using EmployeeApiAppGraphQL.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApiAppGraphQL.DbContextApp
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options){}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
