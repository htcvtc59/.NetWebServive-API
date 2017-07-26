using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamEAP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ExamEAP.EmployeeSerivce.Service employee = new ExamEAP.EmployeeSerivce.Service();
            ExamEAP.EmployeeSerivce.Employee[] list = employee.getAllStudent();
            ViewBag.data = list; 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}