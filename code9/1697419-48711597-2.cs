    static void Main(string[] args)
    {
        System.Threading.Timer timer = new System.Threading.Timer(o => { Console.WriteLine(DateTime.Now); }, "", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
        if (true)
        {
            // declared here and soon out of scope but works until garbage collected.
            new System.Threading.Timer(o => { Console.WriteLine($"Inner {DateTime.Now}"); }, "", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
        }
        Console.ReadLine();  //  wait 5-6 printouts, hit return once
        // force garbage collection. This happens from time to time by itself when your
        // ressources gets scarce and C# runtime "thinks" it is time to GC. 
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.ReadLine();  //  wait some more .. only 1 timer prints anymore
    }
