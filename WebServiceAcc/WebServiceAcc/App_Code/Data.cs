using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Data
/// </summary>
public class Data
{
    public Data()
    {
        //
        // TODO: Add constructor logic here
        //
        
    }
    
        
    public static bool LoginAccount(string user,string pass)
    {
        DataClassesDataContext context = new DataClassesDataContext();
        Account acc = context.Accounts.SingleOrDefault(x => x._user == user && x._pass == pass);
        return acc != null;
    }
}