using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_API.Model
{
    public class EmployeeDepartment
    {
        [Key]
        public int Id { get; set; }
        public string DName { get; set; }
        public string EmployeName { get; set; }
        public string City { get; set; }
    }
}
