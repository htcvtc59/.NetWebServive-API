using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public AccountBank AccountB(string Code, string Pass)
    {
        return new DataBank().AccountB(Code, Pass);
    }

    [WebMethod]
    public AccountBank AccountView(string Code)
    {
        return new DataBank().AccountView(Code);
    }


    [WebMethod]
    public bool LogDraw(AccountBank acc, double money)
    {
        return new DataBank().LogDraw(acc, money);
    }

    [WebMethod]
    public bool LogTranfer(AccountBank acc, double money, string CodeRecieve)
    {
        return new DataBank().LogTranfer(acc, money,CodeRecieve);
    }

    [WebMethod]
    public List<LogBank> ViewLog()
    {
        return new DataBank().ViewLog();
    }

}