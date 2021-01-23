    static void Main(string[] args)
    {
        DoSomething().Wait();
        Console.WriteLine("DoSomething completed");
        Console.ReadKey();
    }
    
    public static async Task DoSomething()
    {
        await Task.Factory.StartNew(() =>
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Doing Something");
                throw new Exception("Something wen't wrong");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        });
    }
