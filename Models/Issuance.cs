using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseManagementSystem.Models
{
    public class Issuance
    {
        [Key]
        public int iss_id { get; set; }
        public DateTime iss_date { get; set; }
        public string emp_name { get; set; }
        public int qnty { get; set; }
    }
}
