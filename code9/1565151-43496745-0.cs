    static void Main()
    {
        using(var fs = File.OpenRead(@"C:\path\to\file.csv"))
        using(var read = new StreamReader(fs))
        {
            while (!read.EndOfStream)
            {
                int i = 0;
                var line = read.ReadLine();
                var values = line.Split(',');
                while (i < values.Length)
                {
                    Console.Write(values[i]);
                    //Console.Read();
                    i++;
                }
                Console.WriteLine();
            }
        }
    }
