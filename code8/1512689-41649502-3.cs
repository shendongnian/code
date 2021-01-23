    string line = "";
    using (var stream = new StreamReader(@"D:\Temp\NewlineAtEnd.txt"))
    {
        while (!stream.EndOfStream)
        {
            line = stream.ReadLineWithNewLine();
            Console.Write(line);
        }
    }
    Console.WriteLine();
    if (line.EndsWith("\n"))
    {
        Console.WriteLine("Newline at end of file");
    }
    else
    {
        Console.WriteLine("No newline at end of file");
    }
