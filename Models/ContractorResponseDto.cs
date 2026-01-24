namespace EmployeesAdminPortal.Models
{
    public class ContractorResponseDto
    {
        public int Id { get; set; }
        public Guid ContractorGuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public String CompanyName { get; set; }

        public List<AddressDto> Addresses { get; set; }
        public List<ContactDto> Contacts { get; set; }
    }

}
