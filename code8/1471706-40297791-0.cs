    class Program
    {
        private static decimal _balance = 100;
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
            var value = (decimal)state;
            var prevBalance = _balance;
            if (_balance >= value)
            {
                 Thread.Sleep(50); // simulate longer operation to emphasize data corruption
                _balance = _balance - value;
                Console.WriteLine("Balance {0}. Withdraw {1}. Balance after withdraw {2}", prevBalance, value, _balance);
            }
            Console.WriteLine("Balance {0}. Withdraw failed", prevBalance);        
        }
    }    
