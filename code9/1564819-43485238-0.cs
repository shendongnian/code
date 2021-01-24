    sting = line;
    using (StreamReader r = new StreamReader("file.txt"))
    {
        line = r.ReadLine();
     }
    Console.WriteLine(line);
    Console.ReadLine();
