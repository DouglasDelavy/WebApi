using Api.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure
{
    public class UnitOfWork
    {
        private ApplicationContext _entities;
        public AccountRepository AccountRepository { get; set; }

        public UnitOfWork(ApplicationContext entities)
        {
            _entities = entities;
            AccountRepository = new AccountRepository(_entities);
        }

        public async Task<int> Commit()
        {
            return _entities.SaveChanges();
        }

        public async Task Dispose()
        {
            _entities.Dispose();
        }
    }
}
