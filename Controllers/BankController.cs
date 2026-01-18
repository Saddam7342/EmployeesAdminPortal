using EmployeesAdminPortal.Data;
using EmployeesAdminPortal.Models;
using EmployeesAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAdminPortal.Controllers
{
    [Route("api/employees/{employeeId:guid}/bankaccounts")]
    [ApiController]
    public class BankController(ApplicationDbContext applicationDbContext) : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;


        [HttpPost]
        public async Task<IActionResult> AddBankAccount(Guid employeeId, AddBankAccountDto bankAccountDto)
        {
            var employee = await applicationDbContext.Employees.FindAsync(employeeId);
            if(employee == null)
            {
                return NotFound("Employee Not Found");
            }
            var account = new BankAccount
            {
                BankName = bankAccountDto.BankName,
                AccountNumber = bankAccountDto.AccountNumber,
                IBAN = bankAccountDto.IBAN,
                EmployeeId = employeeId
            };

            applicationDbContext.BankAccounts.Add(account);
            await applicationDbContext.SaveChangesAsync();
            return Ok(account);
        }
    }
}
