
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        // IActonResult
        public IActionResult Index()
        {
            return View();
        }

        // ActionResut
        public ActionResult About()
        {
            return View();
        }

        // Content Result
        public ContentResult Content()
        {
            return Content("<h1>Hello, I am from Content Result</h1>");
        }

        // Json result
        public JsonResult MyJson()
        {
            return Json(new { name = "Aadarsha", age = 20, address = "Purano Naikap" });
        }

        // redirect result
        public RedirectResult MyProfile()
        {
            return Redirect(url: "http://www.twitter.com/aadarshatweets");
        }

        // partial view
        public PartialViewResult MyPartialView()
        {
            return PartialView("_PartialView");
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel stu)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Message = stu.Fullname + " " + stu.Email; // Message can be named anything
            }

            return View();
        }
    }
}
