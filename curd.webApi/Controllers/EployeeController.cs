using curd.webApi.Data;
using curd.webApi.Models;
using curd.webApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curd.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }


        //Single employee
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployee(Guid id) {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var empolyeeData = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Address = addEmployeeDto.Address,
                Salary = addEmployeeDto.Salary,

            };
            dbContext.Employees.Add(empolyeeData);
            dbContext.SaveChanges();

            return Ok(empolyeeData);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Address = updateEmployeeDto.Address;
            employee.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}
