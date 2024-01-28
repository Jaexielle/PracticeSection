using System;
using System.Collections.Generic;

namespace ProjectAPI.Models;

public partial class DepartmentsInfo
{
    public int DepartmentId { get; set; }

    public string? DepartmentAbrv { get; set; }

    public string? DeparmentDetails { get; set; }

    public virtual ICollection<StudentInfo> StudentInfos { get; set; } = new List<StudentInfo>();
}
