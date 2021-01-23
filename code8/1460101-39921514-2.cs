    using System;
    
    namespace App.Repositories.Contracts
    {
        public interface IUnitOfWork : IDisposable
        {
            IDatabaseTransaction BeginTrainsaction();
            IUserRepository Users { get; }
            IAddressRepository Addresses { get;  }
        }
    }
