using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int emp_id { get; set; }
        public string emp_name { get; set; }
    }
}
