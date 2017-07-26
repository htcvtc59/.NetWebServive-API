using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankATM.Models
{
    public class AccountBank
    {
        public string Code { get; set; }
        public string Pass { get; set; }
        public string FullName { get; set; }
        public double MoneyAmount { get; set; }
    }
}