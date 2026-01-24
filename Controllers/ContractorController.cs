using EmployeesAdminPortal.Data;
using EmployeesAdminPortal.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly IContractorService _contractorService;

        public ContractorController(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllContractors()
        {
            var contractors = await _contractorService.GetAllAsync();
            return Ok(contractors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContractor(
         [FromBody] ContractorDto dto)
        {
            var result = await _contractorService.CreateContractorAsync(dto);
            return Ok(result);
        }
    }
    }
