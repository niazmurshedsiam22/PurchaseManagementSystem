using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseManagementSystem.Models
{
    public class Item
    {
        [Key]
        public int item_id { get; set; }
        public string item_name { get; set; }
        public string item_status { get; set; }
    }
}
