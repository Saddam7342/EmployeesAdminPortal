using EmployeesAdminPortal.Models;

public interface IContractorService
{
    Task<ContractorResponseDto> CreateContractorAsync(
        ContractorDto dto);

    Task<List<ContractorResponseDto>> GetAllAsync();
}
