      static CancellationTokenSource cts;
        static  void Main(string[] args)
        {
            cts = new CancellationTokenSource();
           Task.Factory.StartNew(test);
           cts.Cancel();
        }
        private async static void test()
        {
       
            await function(cts.Token);
        }
        static async Task function(CancellationToken ct)
        {
            try
            {
                while (!ct.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                    //mycode
                }
            }
            catch { }
        }
