     static void Main(string[] args)
    {
        string str = Console.ReadLine();
        if (str == "start")
        {
            Stopwatch sw = new Stopwatch();
            var builder = new StringBuilder();
            
            for (int i = 1; i < 200000; i++)
            {
                sw.Start();
                builder.Clear();
                string a = builder.Append("Acccessed Value").Append(i.ToString()).ToString();
                builder.Clear();
                string b = builder.Append("Time ").Append(sw.ElapsedMilliseconds);
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
        }
        Console.Read();
    }
