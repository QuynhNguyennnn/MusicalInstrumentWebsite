using BusinessObject.Entity;
using DataAccess.DAO;
using DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccountByUserName(string userName) => AccountDAO.Instance.GetAccountByUserName(userName);
        public void InsertAccount(Account account) => AccountDAO.Instance.InsertAccount(account);
        public void ChangePassword(Account account, string oldPassword) => AccountDAO.Instance.ChangePassword(account, oldPassword);    
        public void DeleteAccount(int id) => AccountDAO.Instance.DeleteAccount(id);
    }
}
