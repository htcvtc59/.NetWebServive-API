using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDemoService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string user,string pass)
        {
            ServiceAccount.Service sacc = new ServiceAccount.Service();
            if(sacc.LoginAcc(user, pass))
            {
                ViewBag.Login = "Login Success";
            }else
            {
                ViewBag.Login = "Login Fail";
            }

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