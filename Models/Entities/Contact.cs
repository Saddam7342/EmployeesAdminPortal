namespace EmployeesAdminPortal.Models.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string ContactType { get; set; }
        public string Value { get; set; }
        public bool IsPrimary { get; set; }
        public Guid ContractorId { get; set; }
        public Contractor Contractor { get; set; }
    }
}
