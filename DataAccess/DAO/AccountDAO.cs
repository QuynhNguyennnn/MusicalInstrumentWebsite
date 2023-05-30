using BusinessObject.Entity;
using DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new AccountDAO();
                    }
                }
                return instance;
            }
        }

        public Account GetAccountByUserName(string userName)
        {
            var account = new Account();
            try
            {
                using var context = new Prm392ProjectContext();
                account = context.Accounts.Where(c => c.Username == userName && c.Status == true)
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public void InsertAccount(Account account)
        {
            try
            {
                Account _account = GetAccountByUserName(account.Username);
                if (_account == null)
                {
                    using var context = new Prm392ProjectContext();
                    PasswordHasher passwordHasher = new PasswordHasher();
                    account.Password = passwordHasher.HashPassword(account.Password);
                    context.Accounts.Add(account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Username is already exist.");
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ChangePassword(Account account,  string oldPassword)
        {
            try
            {
                Account _account = GetAccountByUserName(account.Username);
                if (!(_account == null))
                {
                    PasswordHasher passwordHasher = new PasswordHasher();
                    if (passwordHasher.VerifyPassword(oldPassword, _account.Password))
                    {
                        using var context = new Prm392ProjectContext();
                        account.Password = passwordHasher.HashPassword(account.Password);
                        context.Accounts.Update(account);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Password is incorrect.");
                    }
                }
                else
                {
                    throw new Exception("Account is not exist.");
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Account GetAccountById(int id)
        {
            Account? account = new Account();
            try
            {
                using var context = new Prm392ProjectContext();
                account = context.Accounts.Where(c => c.Id == id && c.Status == true)
                    .SingleOrDefault();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public void DeleteAccount(int accountId)
        {
            try
            {
                Account _account = GetAccountById(accountId);
                if (_account != null)
                {
                    using var context = new Prm392ProjectContext();
                    _account.Status = false;
                    context.Accounts.Update(_account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Account is not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
