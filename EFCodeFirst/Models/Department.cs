namespace EFCodeFirst.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public virtual List<Employee> Employees { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
