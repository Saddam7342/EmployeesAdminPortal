using EmployeesAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        //{  
        //}
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
