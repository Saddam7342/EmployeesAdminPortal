namespace EmployeesAdminPortal.Models.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Guid ContractorId { get; set; }
        public Contractor Contractor { get; set; }
    }
}
