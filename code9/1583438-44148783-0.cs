    public void PrintData()
    {
        using (var readtext = new StreamReader(@"c:\Users\IIG\Desktop\demo.txt"))
        {
            while (!readtext.EndOfStream)
            {
                string currentLine = readtext.ReadLine();
                var args = currentLine.Split(' ');
                if (args.Length > 1)
                {
                    Console.WriteLine(args[0] + ":" + args[1]);
                }
                else
                {
                    Console.WriteLine("Invalid line");
                }
            }
        }
    }
