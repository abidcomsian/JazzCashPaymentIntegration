using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JazzCashPaymentIntegration.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace JazzCashPaymentIntegration.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string response = "")
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pay(FormCollection formCollection)
        {
            var model = new CheckOutResponseModel();
            if (!string.IsNullOrEmpty(formCollection["Response"]))
            {
                string pr = formCollection["Response"];
                model = JsonConvert.DeserializeObject<CheckOutResponseModel>(pr);
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
