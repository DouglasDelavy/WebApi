using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository<Account>
    {
        public AccountRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Account> GetByUserName(string userName) =>
            _entities.AccountRepository.Where(x => x.UserName == userName);

        public IQueryable<Account> GetAccountById(int id) =>
            _entities.AccountRepository.Where(x => x.Id == id);

        public IQueryable<Account> GetAllAsync() =>
            _entities.AccountRepository;
    }
}
