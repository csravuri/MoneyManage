using MoneyManage.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

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
                    string dbPath = GetDBFullPath();
                    db = new MoneyManageDB(dbPath);
                }
                return db;
            }
        }

        private static string GetDBLocation()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Data");
        }

        private static string GetDBFullPath()
        {
            string dbFolder = GetDBLocation();
            if(!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }
            return Path.Combine(dbFolder, "MoneyManageDB.db3");
        }

        private MoneyManageDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Person>().Wait();
            database.CreateTableAsync<Transaction>().Wait();

        }

        public Task<List<Transaction>> GetTransactionsAsync()
        {
            return database.Table<Transaction>().ToListAsync();
        }

        public Task<List<Person>> GetPersonsAsync()
        {
            return database.Table<Person>().ToListAsync();
        }

        public Task<Transaction> GetTransactionAsync(int id)
        {
            return database.Table<Transaction>().Where(i => i.transactionID == id).FirstOrDefaultAsync();
        }

        public Task<Person> GetPersonAsync(int id)
        {
            return database.Table<Person>().Where(i => i.personID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveAsync(Transaction item)
        {
            if (item.transactionID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> SaveAsync(Person item)
        {
            if (item.personID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }


        public Task<int> DeleteAsync(Transaction item)
        {
            return database.DeleteAsync<Transaction>(item);
        }

        public Task<int> DeleteAsync(Person item)
        {
            return database.DeleteAsync<Person>(item);
        }

        public bool DeleteAllAsync()
        {
            string dbFullPath = GetDBFullPath();
            if (File.Exists(dbFullPath))
            {
                File.Delete(dbFullPath);
            }
            return true;
        }
    }
}
