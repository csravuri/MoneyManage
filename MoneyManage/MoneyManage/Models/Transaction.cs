using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManage.Models
{
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int transactionID { get; set; }
        public int personID { get; set; }
        public DateTime transactionDate { get; set; }
        public decimal previousBalanceAmount { get; set; }
        public decimal currentBalanceAmount { get; set; }
        public decimal addAmount { get; set; }
        public decimal removeAmount { get; set; }
        public string remarks { get; set; }
        
    }
}
