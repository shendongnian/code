        public int Count
        {
            [SuppressMessage("Microsoft.Concurrency", "CA8001", Justification = "ConcurrencyCop just doesn't know about these locks")]
            get
            {
                int count = 0;
 
                int acquiredLocks = 0;
                try
                {
                    // Acquire all locks
                    AcquireAllLocks(ref acquiredLocks);
 
                    // Compute the count, we allow overflow
                    for (int i = 0; i < m_tables.m_countPerLock.Length; i++)
                    {
                        count += m_tables.m_countPerLock[i];
                    }
 
                }
                finally
                {
                    // Release locks that have been acquired earlier
                    ReleaseLocks(0, acquiredLocks);
                }
 
                return count;
            }
        }
