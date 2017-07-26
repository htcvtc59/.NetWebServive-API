using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankATM.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        int status = 1;

        [HttpPost]
        public ActionResult Index(AccountBank AccB)
        {

            Bank.Service bankservice = new Bank.Service();
            Bank.AccountBank accb = bankservice.AccountB(AccB.Code, AccB.Pass);
            if (accb != null)
            {
                status = 0;
                ViewBag.AccountBB = accb;
                return View("BankATM");
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpGet]
        public ActionResult BankATM()
        {
            if (status == 0)
            {
                return View("BankATM");
            }
            else
            {
                return View("Index");
            }
        }

        Bank.AccountBank AccB = new Bank.AccountBank();

        [HttpGet]
        public ActionResult WithDrawMoney(string code = "")
        {
            if (code != "")
            {
                Bank.Service bankservice = new Bank.Service();
                Bank.AccountBank accb = bankservice.AccountView(code);
                ViewBag.AccountCode = accb.Code;
                return View();
            }
            else
            {
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult WithDrawMoney(string amount, string code)
        {
            Bank.Service bankservice = new Bank.Service();
            Bank.AccountBank accb = bankservice.AccountView(code);
            bankservice.LogDraw(accb, Convert.ToDouble(amount));

            Bank.AccountBank accbb = bankservice.AccountB(accb.Code, accb.Pass);

            status = 0;
            ViewBag.AccountBBB = accbb;
            return View("BankATM");

        }

        [HttpGet]
        public ActionResult TranferMoney(string code = "")
        {
            if (code != "")
            {
                Bank.Service bankservice = new Bank.Service();
                Bank.AccountBank accb = bankservice.AccountView(code);
                ViewBag.AccountCode = accb.Code;
                return View();
            }
            else
            {
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult TranferMoney(string amount, string coderecieve, string codetranfer)
        {
            Bank.Service bankservice = new Bank.Service();
            Bank.AccountBank accb = bankservice.AccountView(codetranfer);
            Bank.AccountBank accrevice = bankservice.AccountView(coderecieve);
            if (accrevice != null)
            {
                bankservice.LogTranfer(accb, Convert.ToDouble(amount), coderecieve);
            }
            Bank.AccountBank accbb = bankservice.AccountB(accb.Code, accb.Pass);
            status = 0;
            ViewBag.AccountBBB = accbb;
            return View("BankATM");
        }


     
        public ActionResult ViewLog()
        {
            Bank.Service bankservice = new Bank.Service();
            List<Bank.LogBank> list = new List<Bank.LogBank>();
            foreach (var item in bankservice.ViewLog())
            {
                list.Add(item);
            }

            ViewBag.ListLog = list;
            return View();
        }

    }
}