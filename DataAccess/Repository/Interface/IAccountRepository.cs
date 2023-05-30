using BusinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface IAccountRepository
    {
        Account GetAccountByEmail(string email);
        void InsertAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(int id);
    }
}
