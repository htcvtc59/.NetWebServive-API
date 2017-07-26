using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataBank
/// </summary>
public class DataBank
{
    public DataBank()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public AccountBank AccountView(string Code)
    {
        DataClassesDataContext context = new DataClassesDataContext();
        return context.AccountBanks.SingleOrDefault(x => x.Code == Code);
    }

    public AccountBank AccountB(string Code, string Pass)
    {
        DataClassesDataContext context = new DataClassesDataContext();
        return context.AccountBanks.SingleOrDefault(x => x.Code == Code && x.Pass == Pass);
    }
    public bool LogDraw(AccountBank acc, double money)
    {
        DataClassesDataContext context = new DataClassesDataContext();
        if (acc != null)
        {
            LogBank log = new LogBank();
            log.Amount = money;
            log.DateTranfer = DateTime.Now;
            log.ReceiveCode = "";
            log.Type = "0";
            context.LogBanks.InsertOnSubmit(log);
            context.SubmitChanges();

            AccountBank accdraw = context.AccountBanks.FirstOrDefault(x => x.Code == acc.Code);
            accdraw.MoneyAmount = accdraw.MoneyAmount - money;
            context.SubmitChanges();

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool LogTranfer(AccountBank acc, double money, string CodeRecieve)
    {
        DataClassesDataContext context = new DataClassesDataContext();
        if (acc != null)
        {
            LogBank log = new LogBank();
            log.Amount = money;
            log.DateTranfer = DateTime.Now;
            log.ReceiveCode = CodeRecieve;
            log.Type = "1";
            context.LogBanks.InsertOnSubmit(log);
            context.SubmitChanges();

            AccountBank accdraw = context.AccountBanks.FirstOrDefault(x => x.Code == acc.Code);
            accdraw.MoneyAmount = accdraw.MoneyAmount - money;
            AccountBank acctranfer = context.AccountBanks.FirstOrDefault(x => x.Code == CodeRecieve);
            acctranfer.MoneyAmount = acctranfer.MoneyAmount + money;

            context.SubmitChanges();

            return true;
        }
        else
        {
            return false;
        }
    }

    public List<LogBank> ViewLog()
    {
        DataClassesDataContext context = new DataClassesDataContext();
        return context.LogBanks.ToList();
    }
}