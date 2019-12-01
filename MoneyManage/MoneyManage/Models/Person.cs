using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManage.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int personID { get; set; }

        [Unique]
        public string personName { get; set; }

        public string mobileNo { get; set; }
        
        public string email { get; set; }

        public string address { get; set; }

        public decimal balanceAmount { get; set; }

        public DateTime createdDate { get; set; }

    }
}
