using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBPriceQuotation.Models;

namespace SBPriceQuotation.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This is a method for Get request from the client.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            //Follwing displays the initial state of the Index Screen.
            //The DA and Ttl properties are auto available to the view and controller of this app.
            ViewBag.DA = 0;
            ViewBag.Ttl = 0;
            return View();
        }
        [HttpPost]
        // This is a custom method for for POST request display.
        public IActionResult Index(PriceQuotationModel model)
        {
            //Action Method that checks for Invalid Data.
            if (ModelState.IsValid)
            {
                //App Continues calculations and pull the model from the CalculateDisAmount() and CalculateQuotationTotal() method from PriceQuotationModel.cs class.
                ViewBag.DA = model.CalculateDisAmount();
                ViewBag.Ttl = model.CalculateQuotationTotal();
            }
            else
            {
                //Displays the blank values.
                ViewBag.DA = 0;
                ViewBag.Ttl = 0;
            }
            //Passes in the model for client view.
            return View(model);
        }
    }
}
