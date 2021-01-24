    void Main()
    {
	    Test();	
    }
    void Test()
    {
	    var t = new Task(() => {
		    var rnd = new Random(DateTime.Now.Millisecond);
		    int countdown = 5;
		    while (true)
		    {
                Thread.Sleep(10);
                var nextRand = rnd.Next(5);
                Console.WriteLine(nextRand);
                if (nextRand == 0)
                {
                    countdown--;
                    if (countdown == 1) return;
                }
            }
        });
        var t2 = t.ContinueWith(_ => { });
        t.Start();
        t2.Wait();
        Console.WriteLine("Thread ended");
    }
