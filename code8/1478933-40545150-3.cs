    public class SharedVariable<T>
    {
        // The shared value:
        private T value;
        
        // The ReaderWriterLockSlim instance protecting concurrent access to the shared variable's value:
        private ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();
        
        // Constructor
        public SharedVariable(T val)
        {
            this.value = val;
        }
    
        // Gets or sets the value with thread-safe locking and notifying value changes 
        public T Value 
        {
            get
            {
                readerWriterLock.EnterReadLock();
                try
                {
                    return value;
                }
                finally
                {
                    readerWriterLock.ExitReadLock();
                }
            }
        
            set
            {
                readerWriterLock.EnterWriteLock();
                try
                {
                    if (!this.value.Equals(value))
                    {
                        this.value = value;
                    }
                }
                finally
                {
                    readerWriterLock.ExitWriteLock();
                }
            }
        }
        
        // GetAndSet allows to thread-safely read and change the shared variable's value as an atomic operation. 
        // The update parameter is a lamda expression computing the new value from the old one. 
        // Example: 
        // SharedVariable<int> sharedVariable = new SharedVariable<int>(0);
        // sharedVariable.GetAndSet((v) => v + 1);  // Increments the sharedVariable's Value.
        public void GetAndSet(Func<T,T> update)
        {
            readerWriterLock.EnterWriteLock();
            try
            {
                T newValue = update(this.value);
                if (!this.value.Equals(newValue))
                {
                    this.value = newValue;
                }
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
            }
        }
    }
