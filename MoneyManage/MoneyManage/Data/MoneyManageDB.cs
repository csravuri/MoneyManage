using MoneyManage.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MoneyManage.Data
{
    public class MoneyManageDB
    {
        readonly SQLiteAsyncConnection database;

        private static MoneyManageDB db;
        public static MoneyManageDB Database
        {
            get
            {
                if (db == null)
                {
                    db = new MoneyManageDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Data", "MoneyManageDB.db3"));
                }
                return db;
            }
        }

        private MoneyManageDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Person>().Wait();
            database.CreateTableAsync<Transaction>().Wait();

        }

        public void Read<T>()
        {
            
        }


    }
}
