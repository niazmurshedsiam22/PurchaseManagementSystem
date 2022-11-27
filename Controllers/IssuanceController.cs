using Microsoft.AspNetCore.Mvc;
using PurchaseManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseManagementSystem.Controllers
{
    public class IssuanceController : Controller
    {
        public readonly ConnectionStringClass connectionStringClass;
        public IssuanceController(ConnectionStringClass cc)
        {
            this.connectionStringClass = cc;
        }
        public IActionResult Index()
        {
            IList<Issuance> issuance = connectionStringClass.issuances.OrderByDescending(x => x.iss_id).ToList();
            return View(issuance);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Issuance issuance)
        {
            if (issuance != null)
            {
                connectionStringClass.issuances.Add(issuance);
                connectionStringClass.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Issuance issuance = connectionStringClass.issuances.Where(x => x.iss_id == id).SingleOrDefault();
            return View(issuance);
        }
        [HttpPost]
        public IActionResult Edit(Issuance issuance)
        {
            Issuance issuance1 = connectionStringClass.issuances.Where(x => x.iss_id == issuance.iss_id).SingleOrDefault();
            issuance1.iss_date = issuance.iss_date;
            issuance1.emp_name = issuance.emp_name;
            issuance1.qnty = issuance.qnty;
            connectionStringClass.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Issuance issuance = connectionStringClass.issuances.Where(x => x.iss_id == id).SingleOrDefault();
            return View(issuance);
        }
        [HttpPost]
        public IActionResult Delete(Issuance issuance)
        {
            Issuance issuance1 = connectionStringClass.issuances.Where(x => x.iss_id == issuance.iss_id).SingleOrDefault();
            connectionStringClass.issuances.Remove(issuance1);
            connectionStringClass.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Issuance issuance = connectionStringClass.issuances.Where(x => x.iss_id == id).SingleOrDefault();
            return View(issuance);
        }
    }
}
