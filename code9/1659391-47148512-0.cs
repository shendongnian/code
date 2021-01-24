    public class ThreadingIssue
    {
        int accum;
        private readonly object _syncLock = new object();
    
        public void Squaring(int x)
        {
            // Creates a random pause to check for thread
            int pauseFor = rnd.Next(1, 10);
            Thread.Sleep(pauseFor);
    
            lock( _syncLock ) 
            {
               accum += x*x;
            }
         }
    
         public void DoSquaring()
         {
           accum = 0;
           for (int i = 1; i <= 100; i++)
           {
              int number = i;
              threads.Add(new Thread(() => Squaring(number)));
              threads[i - 1].Start();
           }
          }
        }
