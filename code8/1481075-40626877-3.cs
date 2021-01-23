        public void Create(Guid key)
        {
            _transactionProvider.BeginTransaction();
            try
            {
                _repo1.Create(key);
                _repo2.Create(key);
                _transactionProvider.CommitTransaction();
            }
            catch (Exception)
            {
                _transactionProvider.RollbackTransaction();
                throw;
            }
            finally
            {
                _transactionProvider.DisposeTransaction();
            }
        }
