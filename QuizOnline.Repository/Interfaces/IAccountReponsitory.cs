using QuizOnlineDatabase;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizOnline.Reponsitory.Interfaces
{
    public interface IAccountReponsitory : IReponsitory<Account> 
    {
        Account Authenticate(string UseName, string Password);
        //IEnumerable<User> GetAll();
        //User GetById(int id);
        Account Create(Account Account, string Password);
        void Update(Account Account, string Password = null);
        void Delete(int id);
    }
}
