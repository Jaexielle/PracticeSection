using System;
using System.Collections.Generic;

namespace ProjectAPI.Models;

public partial class StudentInfo
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? Gender { get; set; }

    public int? PhoneNumber { get; set; }

    public string? EmailAddreiss { get; set; }

    public int? Department { get; set; }

    public virtual DepartmentsInfo? DepartmentNavigation { get; set; }
}
