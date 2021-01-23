        public void Dispose()
        {
            if (_thereWasAnError)
            {
                Task.Run(async () => await RollbackAsync()).Wait();
            }
        }
