using System.Net;

namespace EmployeesAdminPortal.Models.Entities
{
    public class Contractor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string NTN { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
