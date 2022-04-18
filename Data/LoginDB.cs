using MAUIAppBase.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIAppBase.Data
{
    public class LoginDB
    {
        readonly SQLiteAsyncConnection LDB;
        
        public LoginDB(string dbPath)
        {
            LDB = new SQLiteAsyncConnection(dbPath);
            LDB.CreateTableAsync<LoginDBModel>().Wait();
        }

        public Task<List<LoginDBModel>> GetData()
        {
            return LDB.Table<LoginDBModel>().ToListAsync();
        }

        public Task<int> SaveItemSync(LoginDBModel model)
        {
            return LDB.InsertAsync(model);
        }

        public Task<int> DeleteItemAsync(LoginDBModel model)
        {
            return LDB.DeleteAsync(model);
        }

        public Task<int> DeleteAllAsync()
        {
            return LDB.DeleteAllAsync<LoginDBModel>();
        }
    }
}
