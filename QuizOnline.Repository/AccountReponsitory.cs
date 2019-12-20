using QuizOnline.Common.Infrastructure.Helper;
using QuizOnline.Reponsitory.Interfaces;
using QuizOnlineDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizOnline.Reponsitory
{
    public class AccountReponsitory : BaseReponsitory<Account>, IAccountReponsitory
    {
        public AccountReponsitory(QuizOnlineDbContext dbContext) : base(dbContext)
        {
        }

        public Account Authenticate(string UseName, string Password)
        {
            if (string.IsNullOrEmpty(UseName) || string.IsNullOrEmpty(Password))
                return null;

            var Account = DbContext.Accounts.SingleOrDefault(x => x.UserName == UseName);

            // check if username exists
            if (Account == null)
                return null;

            // check if password is correct
            if (!AuthenAccountHelper.VerifyPasswordHash(Password, Account.PasswordHash, Account.PasswordSalt))
                return null;

            // authentication successful
            return Account;
        }

        public Account Create(Account Account, string Password)
        {
            if (string.IsNullOrWhiteSpace(Password))
                throw new Exception("Password is required");

            if (DbContext.Accounts.Any(x => x.UserName == Account.UserName))
                throw new Exception("UserName \"" + Account.UserName + "\" is already taken");

            byte[] passwordHash;
            byte[] passwordSalt;

            AuthenAccountHelper.CreatePasswordHash(Password, out passwordHash, out passwordSalt);

            Account.PasswordHash = passwordHash;
            Account.PasswordSalt = passwordSalt;

            DbContext.Accounts.Add(Account);
            DbContext.SaveChanges();

            return Account;
        }

        public void Delete(int id)
        {

            var Account = DbContext.Accounts.Find(id);
            if (Account != null)
            {
                DbContext.Accounts.Remove(Account);
                DbContext.SaveChanges();
            }
        }

        public void Update(Account AccountParam, string Password = null)
        {
            var Account = DbContext.Accounts.Find(AccountParam.Id);

            if (Account == null)
                throw new Exception("User not found");

            if (AccountParam.UserName != Account.UserName)
            {
                // username has changed so check if the new username is already taken
                if (DbContext.Accounts.Any(x => x.UserName == AccountParam.UserName))
                    throw new Exception("Username " + AccountParam.UserName + " is already taken");
            }
            
            // update user properties
            Account.PhoneNumber = AccountParam.PhoneNumber;
            Account.UserName = AccountParam.UserName;
            Account.FirstName = AccountParam.FirstName;
            Account.LastName = AccountParam.LastName;
            Account.Address = AccountParam.Address;
            Account.Gmail = AccountParam.Gmail;
            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(Password))
            {
                byte[] passwordHash, passwordSalt;
                AuthenAccountHelper.CreatePasswordHash(Password, out passwordHash, out passwordSalt);

                Account.PasswordHash = passwordHash;
                Account.PasswordSalt = passwordSalt;
            }

            DbContext.Accounts.Update(Account);
            DbContext.SaveChanges();
        }
    }
}
