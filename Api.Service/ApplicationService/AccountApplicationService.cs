using Api.CrossCuting.DTO;
using Api.Domain.Models;
using Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.ApplicationService
{
    public class AccountApplicationService : GenericApplicationService
    {
        public AccountApplicationService(UnitOfWork uow) : base(uow)
        {
        }

        public async Task<Account> CreateNewAccount(string userName)
        {
            var account = await _uow.AccountRepository.GetByUserName(userName).FirstOrDefaultAsync();
            var newAccount = new Account
            {
                UserName = userName,
                Guid = Guid.NewGuid().ToString(),
            };

            if (account == null)
            {
                _uow.AccountRepository.Add(newAccount);

                await _uow.Commit();
            }

            return account != null ? account : newAccount;
        }

        public async Task UpdateUserNameAccount(int userId,string userName)
        {
            var account = await _uow.AccountRepository.GetAccountById(userId).FirstOrDefaultAsync();

            if (account != null)
            {
                account.UserName = userName;
            }

            await _uow.Commit();
        }

        public async Task<Account> GetAccountById(int userId)
        {
            var account = await _uow.AccountRepository.GetAccountById(userId).FirstOrDefaultAsync();
            return account;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            var accounts = await _uow.AccountRepository.GetAllAsync().ToListAsync();
            return accounts;
        }

        public async Task DeleteAccountById(int userId)
        {
            var account = _uow.AccountRepository.GetById(userId);

            if (account != null)
            {
                _uow.AccountRepository.Delete(account);
            }

            await _uow.Commit();
        }
    }
}
