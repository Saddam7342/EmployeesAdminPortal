using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EmployeesAdminPortal.Models.Entities
{
    public class Contractor
    {
        [Key]
        public int Id { get; set; }          

        //public int Id { get; set; }          
        public Guid ContractorGuid { get; set; } 

        public string Name { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
