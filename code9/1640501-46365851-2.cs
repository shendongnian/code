            internal class ReaderFreadlyLock<T>
            {
                private readonly ReaderWriterLockSlim lck = new ReaderWriterLockSlim();
    
                public T Read(Func<T> func)
                {
                    this.lck.EnterReadLock();
                    try
                    {
                        return func();
                    }
                    finally
                    {
                        this.lck.ExitReadLock();
                    }
                }
    
                public void Write(Action action)
                {
    
                    this.lck.EnterReadLock();
                    try
                    {
                        action();
                    }
                    finally
                    {
                        this.lck.ExitWriteLock();
                    }
                }
            }
