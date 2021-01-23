    using System;
    
        namespace Support.Repositories.Contracts
        {
            public interface IDatabaseTransaction : IDisposable
            {
                void Commit();
        
                void Rollback();
            }
        }
    
    
