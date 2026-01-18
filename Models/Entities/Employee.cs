namespace EmployeesAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int Age { get; set; }
        public  string? Phone { get; set; }

        public decimal Salary { get; set; }

        public bool IsVerified { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    }
}
