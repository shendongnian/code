    internal static class Program
    {
        // ...
    
        static void Main(string[] args)
        {
            // ...
            // this line is equivalent of
            // cts.Token.Register(new Action<object>(OnCancelled), null, true);
            cts.Token.Register(OnCancelled, null, true);
            // ...
        }
         
        // ...
    
        static void OnCancelled(object state)
        {
            Console.WriteLine(state);
        }
    }
