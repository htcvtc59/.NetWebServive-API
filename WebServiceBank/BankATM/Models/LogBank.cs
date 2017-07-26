using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankATM.Models
{
    public class LogBank
    {
        public int ID { get; set; }
        public DateTime DateTranfer { get; set; }
        public string CodeRecieve { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
    }
}