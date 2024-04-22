namespace EFCodeFirst.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public virtual List<Department> Departments { get; set; }
    }
}