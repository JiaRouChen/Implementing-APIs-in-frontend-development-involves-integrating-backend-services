using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyWebAPI.Models;

public partial class Department
{
    [Required(ErrorMessage ="科系代碼必填")]
    public string DeptID { get; set; } = null!;

    [Required(ErrorMessage = "科系名稱必填")]
    public string DeptName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<tStudent>? tStudent { get; set; } = new List<tStudent>();

    
}
