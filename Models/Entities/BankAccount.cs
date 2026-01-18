namespace EmployeesAdminPortal.Models.Entities
{
    public class BankAccount
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string IBAN { get; set; } = string.Empty;

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
