        /// <summary>
        /// Copies the key and value pairs stored in the <see cref="ConcurrentDictionary{TKey,TValue}"/> to a
        /// new array.
        /// </summary>
        /// <returns>A new array containing a snapshot of key and value pairs copied from the <see
        /// cref="ConcurrentDictionary{TKey,TValue}"/>.</returns>
        [SuppressMessage("Microsoft.Concurrency", "CA8001", Justification = "ConcurrencyCop just doesn't know about these locks")]
        public KeyValuePair<TKey, TValue>[] ToArray()
        {
            int locksAcquired = 0;
            try
            {
                AcquireAllLocks(ref locksAcquired);
                int count = 0;
                checked
                {
                    for (int i = 0; i < m_tables.m_locks.Length; i++)
                    {
                        count += m_tables.m_countPerLock[i];
                    }
                }
 
                KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[count];
 
                CopyToPairs(array, 0);
                return array;
            }
            finally
            {
                ReleaseLocks(0, locksAcquired);
            }
        }
