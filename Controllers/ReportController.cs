using Microsoft.AspNetCore.Mvc;
using PurchaseManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly ConnectionStringClass connectionStringClass;

        public ReportController(ConnectionStringClass cc)
        {
            connectionStringClass = cc;
        }
        public IList<Item> Items;

        public IList<Purchase> purchases;

        public IList<Issuance> issuances;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AllItemData()
        {
            return new Rotativa.AspNetCore.ViewAsPdf(connectionStringClass.items.OrderBy(x => x.item_id).ToList());
        }
        [HttpGet]
        public IActionResult ItemData()
        {
            Items = connectionStringClass.items.OrderBy(x => x.item_id).ToList();
            return View(Items);
        }

        [HttpPost]
        public IActionResult SearchItemData(string Data)
        {
            DataClass data = new DataClass(connectionStringClass);
            Items = data.getItemsData(Data);
            TempData["Data"] = Data;
            return View(Items);
        }

        [HttpGet]
        public IActionResult ItemReport()
        {
            DataClass data = new DataClass(connectionStringClass);
            var myData = TempData["Data"];
            IList<Item> searchItems = data.getItemsData(myData.ToString());
            return new Rotativa.AspNetCore.ViewAsPdf(searchItems);
        }

        [HttpGet]
        public IActionResult ALLPurchaseData()
        {
            return new Rotativa.AspNetCore.ViewAsPdf(connectionStringClass.purchases.OrderBy(x => x.pur_id).ToList());
        }
        [HttpGet]
        public IActionResult PurchaseData()
        {
            purchases = connectionStringClass.purchases.OrderBy(x => x.pur_id).ToList();
            return View(purchases);
        }

        [HttpPost]
        public IActionResult searchPurchaseData(string Data)
        {
            DataClass dataClass = new DataClass(connectionStringClass);
            purchases = dataClass.getPurchasesData(Data);
            TempData["Data"] = Data;
            return View(purchases);

        }
        [HttpGet]
        public IActionResult purchaseReport()
        {
            DataClass dataClass = new DataClass(connectionStringClass);
            var myList = TempData["Data"];
            IList<Purchase> purchasesList = dataClass.getPurchasesData(myList.ToString());
            return new Rotativa.AspNetCore.ViewAsPdf(purchasesList);
        }

        [HttpGet]
        public IActionResult ALLIssuanceReport()
        {
            return new Rotativa.AspNetCore.ViewAsPdf(connectionStringClass.issuances.OrderBy(x => x.iss_id).ToList());
        }
        [HttpGet]
        public IActionResult IssuanceData()
        {
            IList<Issuance> list = connectionStringClass.issuances.OrderBy(x => x.iss_id).ToList();
            return View(list);
        }
        [HttpPost]
        public IActionResult showIssuance(string Data)
        {
            DataClass data = new DataClass(connectionStringClass);
            issuances = data.getIssuancesData(Data);
            TempData["data"] = Data;
            return View(issuances);

        }
        [HttpGet]
        public IActionResult issuanceReport()
        {
            DataClass data = new DataClass(connectionStringClass);
            var myList = TempData["data"];
            IList<Issuance> myData = data.getIssuancesData(myList.ToString());
            return new Rotativa.AspNetCore.ViewAsPdf(myData);
        }
    }
}
