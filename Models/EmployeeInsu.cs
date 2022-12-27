using System;
using System.Collections.Generic;

namespace EmpFD.Models;

public partial class EmployeeInsu
{
    public int EmployeeCode { get; set; }

    public string NomineeName { get; set; } = null!;

    public string? NomineeType { get; set; }

    public string? NomineeDob { get; set; }

    public string? NomineeAge { get; set; }

    public string? InsurenceNo { get; set; }

    public int? Premium { get; set; }
}
