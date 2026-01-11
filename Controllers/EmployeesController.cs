using EmployeesAdminPortal.Data;
using EmployeesAdminPortal.Models;
using EmployeesAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public EmployeesController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees =  applicationDbContext.Employees.ToList();
           
          
            return Ok(allEmployees);

        }


        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
           var employee = applicationDbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);

            }

        }


        [HttpGet]
        [Route("{name}")]
        public IActionResult GetEmployeeByName(string name)
        {
            var employee = applicationDbContext.Employees.FirstOrDefault(e=> e.Name.ToLower() == name.ToLower());
            if (employee is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }


        [HttpPost]
        public IActionResult addEmployee(AddEmployeeDto employeeDto)
        {
            var employeeEntity = new Employee() {
                Email = employeeDto.Email,
                Name = employeeDto.Name,
                
                Age = employeeDto.Age,
                Phone= employeeDto.Phone,
                Salary= employeeDto.Salary,

            };
            applicationDbContext.Employees.Add(employeeEntity);
            applicationDbContext.SaveChanges();
            return Ok("Employee added successfully");

        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult updateEmployeeById(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = applicationDbContext.Employees.Find(id);
            if (employee is null) return NotFound();

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Age = updateEmployeeDto.Age;
            employee.Phone = updateEmployeeDto.Phone;
         
            employee.Salary = updateEmployeeDto.Salary;
            applicationDbContext.SaveChanges();
            return Ok(employee);

        }



        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult deleteEmployeeById(Guid id)
        {
            var employee = applicationDbContext.Employees.Find(id);
            if (employee is null) return NotFound();
            applicationDbContext.Employees.Remove(employee);
            applicationDbContext.SaveChanges();
            return Ok("Employee removed successfully");
        }
    }
}
