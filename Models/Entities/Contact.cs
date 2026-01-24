namespace EmployeesAdminPortal.Models.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }

        public string Phone { get; set; }
        public string Type { get; set; }
    }
}
