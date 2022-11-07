using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseManagementSystem.Models
{
    public class Purchase
    {
        [Key]
        public int pur_id { get; set; }
        public string pur_item { get; set; }
        public int pur_qnty { get; set; }
        public DateTime pur_date { get; set; }
        public int pur_price { get; set; }
        public string vendor { get; set; }

    }
}
