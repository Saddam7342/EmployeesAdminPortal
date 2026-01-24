using EmployeesAdminPortal.Data;
using EmployeesAdminPortal.Models;
using EmployeesAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;
 

public class ContractorService : IContractorService
{
    private readonly ApplicationDbContext _context;

    public ContractorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ContractorResponseDto> CreateContractorAsync(
        ContractorDto dto)
    {
        // 1. Business validation
        bool exists = await _context.Contractors
            .AnyAsync(c => c.Email == dto.Email);

        if (exists)
            throw new Exception("Contractor with this email already exists");

        // 2. Map DTO → Entity
        var contractor = new Contractor
        {
            Name = dto.Name,
            Email = dto.Email,
            CompanyName = dto.CompanyName,
            ContractorGuid = Guid.NewGuid()
        };

        foreach (var addr in dto.Addresses)
        {
            contractor.Addresses.Add(new Address
            {
                Street = addr.Street,
                City = addr.City,
                Country = addr.Country
            });
        }

        foreach (var contact in dto.Contacts)
        {
            contractor.Contacts.Add(new Contact
            {
                Phone = contact.Phone,
                Type = contact.Type
            });
        }

        // 3. Save once (transaction-safe)
        _context.Contractors.Add(contractor);
        await _context.SaveChangesAsync();

        // 4. Map Entity → Response DTO
        return new ContractorResponseDto
        {
            ContractorGuid = contractor.ContractorGuid,
            Name = contractor.Name,
            Email = contractor.Email,
            CompanyName = contractor.CompanyName,
            Addresses = contractor.Addresses.Select(a => new AddressDto
            {
                Street =a.Street,
                City = a.City,
                Country = a.Country
            }).ToList(),
            Contacts = contractor.Contacts.Select(c => new ContactDto
            {
                Phone = c.Phone,
                Type = c.Type
            }).ToList()
        };
    }


    public async Task<List<ContractorResponseDto>> GetAllAsync()
    {
        var contractors = await _context.Contractors
            .Include(c => c.Addresses)
            .Include(c => c.Contacts)
            .AsNoTracking()
            .ToListAsync();

        return contractors.Select(c => new ContractorResponseDto
        {
            ContractorGuid = c.ContractorGuid,
            Name = c.Name,
            Email = c.Email,

            Addresses = c.Addresses.Select(a => new AddressDto
            {
                City = a.City,
                Country = a.Country
            }).ToList(),

            Contacts = c.Contacts.Select(ct => new ContactDto
            {
                Phone = ct.Phone,
                Type = ct.Type
            }).ToList()

        }).ToList();
    }

}
