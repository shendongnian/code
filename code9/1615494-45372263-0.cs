    static void Main(string[] args)
    {
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;
         
        Task task1 = new Task(() => Factorial(5, token));
        task1.Start();
         
        Console.WriteLine("Type Y to break the loop:");
        string s = Console.ReadLine();
        if (s == "Y")
            cancelTokenSource.Cancel();
     
        Console.ReadLine();
    }
     
    static void Factorial(int x, CancellationToken token)
    {
        int result = 1;
        for (int i = 1; i <= x; i++)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Canceled");
                return;
            }
     
            result *= i;
            Console.WriteLine("Factorial of {0} equals {1}", i, result);
        }
    }
