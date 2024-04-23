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
        private readonly string[] _gender = { "None", "Nam", "Nữ", "Không xác định" };

        public ExampleController(CompanyDbContext context)
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
                                                Age = e.Age,
                                                Gender = _gender[e.Gender],
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
