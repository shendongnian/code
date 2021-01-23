    using System;
    
    namespace App.Repositories.Contracts
    {
        public interface IUnitOfWork : IDisposable
        {
            IDatabaseTransaction BeginTransaction();
            IUserRepository Users { get; }
            IAddressRepository Addresses { get;  }
        }
    }
