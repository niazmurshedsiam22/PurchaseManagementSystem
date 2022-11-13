using Microsoft.AspNetCore.Mvc;
using PurchaseManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseManagementSystem.Controllers
{
    public class PurchaseController : Controller
    {
        public readonly ConnectionStringClass connectionStringClass;
        public PurchaseController(ConnectionStringClass cc)
        {
            this.connectionStringClass = cc;
        }
        public IActionResult Index()
        {
            IList<Purchase> purchase = connectionStringClass.purchases.OrderByDescending(x => x.pur_id).ToList();
            return View(purchase);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Purchase purchase)
        {
            if (purchase != null)
            {
                connectionStringClass.purchases.Add(purchase);
                connectionStringClass.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Purchase purchase = connectionStringClass.purchases.Where(x => x.pur_id == id).SingleOrDefault();
            return View(purchase);
        }
        [HttpPost]
        public IActionResult Edit(Purchase purchase)
        {
            Purchase purchase1 = connectionStringClass.purchases.Where(x => x.pur_id == purchase.pur_id).SingleOrDefault();
            purchase1.pur_item = purchase.pur_item;
            purchase1.pur_price = purchase.pur_price;
            purchase1.pur_qnty = purchase.pur_qnty;
            purchase1.vendor = purchase.vendor;
            connectionStringClass.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Purchase purchase = connectionStringClass.purchases.Where(x => x.pur_id == id).SingleOrDefault();
            return View(purchase);
        }
        [HttpPost]
        public IActionResult Delete(Purchase purchase)
        {
            Purchase purchase1 = connectionStringClass.purchases.Where(x => x.pur_id == purchase.pur_id).SingleOrDefault();
            connectionStringClass.purchases.Remove(purchase1);
            connectionStringClass.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Details(int id)
        {
            Purchase purchase = connectionStringClass.purchases.Where(x => x.pur_id == id).SingleOrDefault();
            return View(purchase);
        }
    }
}
