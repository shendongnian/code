    class Account
    {
        decimal balance;
        private Object thisLock = new Object();
        private Object thisLock2 = new Object();
        public void Withdraw(decimal amount)
        {
            lock (thisLock)
            {
                if (amount > balance)
                {
                    throw new Exception("Insufficient funds");
                }
                balance -= amount;
            }
            // more code here but no locking necessary...
            lock(thisLock)
            {
                // only one thread can enter here who has thisLock
            }
            lock (thisLock2)
            {
                // If T1 (thread1) is working with thisLock, T2 can come here since it has nothing to do
                // with thisLock.
            }
        }
        public void AnotherOperation()
        {
            lock (thisLock)
            {
                // code here...
            }
        }
        public void YetAnotherOperation()
        {
            lock (thisLock)
            {
                // code here...
            }
        }
    }
