using EFCodeFirst.data_access;
using EFCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public ExampleController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees(int fromAge, int toAge, string departmentName)
        {
            var employee = _context.Employees.Where(e => e.Department.DepartmentName.Equals(departmentName)
                                                            && e.Age >= fromAge
                                                            && e.Age <= toAge);

            if (employee == null)
            {
                return NotFound();
            }

            return await employee.ToListAsync();
        }
    }
}
