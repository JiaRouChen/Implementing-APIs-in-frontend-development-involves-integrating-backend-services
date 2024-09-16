using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyWebAPI.Models;

public partial class tStudent
{
    public string fStuId { get; set; }

    public string fName { get; set; } = null!;

    public string? fEmail { get; set; }

    public int? fScore { get; set; }

    public string DeptID { get; set; } = null!;

    [JsonIgnore]
    public virtual Department? Dept { get; set; }
}
