using CTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTaxi.Controllers
{
   
    public class DriversController : Controller
    {

        private static Drivers _drivers = new Drivers();

        //
        // GET: /Drivers/         
        public ActionResult Index()
        {
            var list = _drivers._driverList.OrderByDescending(x => x.SeniorityInDays).ToList();

            return View(list);
        }

        
        //
        // GET: /Drivers/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Drivers/Create
        [HttpPost]
        public ActionResult Create(DriverModels driverModels)
        {
            _drivers.AddDriver(driverModels);
            return RedirectToAction("Index");
        }

        //
        // GET: /Drivers/Delete/5
        public ActionResult Delete(int licenceNum)
        {
            var driver = _drivers._driverList.Single(d => d.LicenceNum == licenceNum);
            return View(driver);
        }

        //
        // POST: /Drivers/Delete/5
        [HttpPost]
        public ActionResult Delete(int licenceNum, FormCollection collection)
        {
            var driver = _drivers._driverList.Single(d => d.LicenceNum == licenceNum);
            
            if (TryUpdateModel(driver))
            {
                _drivers.DeleteDriver(driver);
                return RedirectToAction("Index");
            }
            return View(driver);
        }

       //
       // GET: /Drivers/Edit/5

       public ActionResult Edit(int licenceNum)
       {
           var driver = _drivers._driverList.Single(d => d.LicenceNum == licenceNum);

           return View(driver);
       }

       //
       // POST: /Drivers/Edit/5

       [HttpPost]
       public ActionResult Edit(int licenceNum, FormCollection collection)
       {
           var driver = _drivers._driverList.Single(d => d.LicenceNum == licenceNum);

           if (TryUpdateModel(driver))
           {
               return RedirectToAction("Index");
           }
           return View(driver);
            
       }
        
    }
}
