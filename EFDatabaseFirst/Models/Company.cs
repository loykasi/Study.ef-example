using System;
using System.Collections.Generic;

namespace EFDatabaseFirst.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
