using System.ComponentModel.DataAnnotations;

namespace EmployeesAdminPortal.Models.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
