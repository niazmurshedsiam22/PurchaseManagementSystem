using Microsoft.AspNetCore.Mvc;
using PurchaseManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseManagementSystem.Controllers
{
    public class ItemController : Controller
    {
        public readonly ConnectionStringClass connectionStringClass;
        public ItemController(ConnectionStringClass cs)
        {
            this.connectionStringClass = cs;
        }
        public IActionResult Display()
        {
            IList<Item> list = connectionStringClass.items.OrderByDescending(z => z.item_id).ToList();
            return View(list);
        }
    }
}
