using EFDatabaseFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFDatabaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly CompanyDatabaseFirstDbContext _context;
        private readonly string[] _gender = { "Not known", "Male", "Female", "Not applicable" };

        public ExampleController(CompanyDatabaseFirstDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailEmployee>>> GetEmployees(int fromAge, int toAge, string departmentName)
        {
            var employee = _context.Employees.Where(e => e.Department.DepartmentName.Equals(departmentName)
                                                            && e.Age >= fromAge
                                                            && e.Age <= toAge)
                                            .Select(e => new DetailEmployee
                                            {
                                                EmployeeId = e.EmployeeId,
                                                EmployeeName = e.EmployeeName,
                                                Age = e.Age ?? 0,
                                                Gender = _gender[e.Gender ?? 0],
                                                DepartmentName = e.Department.DepartmentName
                                            });

            if (employee == null)
            {
                return NotFound();
            }

            return await employee.ToListAsync();
        }
    }
}
