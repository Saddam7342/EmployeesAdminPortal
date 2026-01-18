namespace EmployeesAdminPortal.Models
{
    public class ContractorDto
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string NTN { get; set; }

        public List<AddressDto> Addresses { get; set; }
        public List<ContactDto> Contacts { get; set; }
    }
}
