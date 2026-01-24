using EmployeesAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }

    }
}
