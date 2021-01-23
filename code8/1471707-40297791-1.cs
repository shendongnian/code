    class Program
    {
        private static decimal _balance = 100;
        private static readonly object _balanceLocker = new object();
        static void Main(string[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Withdraw, 23m);
            }
            
            Console.ReadLine();
        }
        private static void Withdraw(object state)
        {
            lock (_balanceLocker)
            {
                var value = (decimal)state;
                var prevBalance = _balance;
                if (_balance >= value)
                {
                    Thread.Sleep(50); // simulate longer operation to emphasize data corruption
                    _balance = _balance - value;
                    Console.WriteLine("Balance {0}. Withdraw {1}. Balance after withdraw {2}", prevBalance, value, _balance);
                    return;
                }
                Console.WriteLine("Balance {0}. Withdraw {1}. Withdraw failed", prevBalance, value);
            }
        }
    }    
