    void PrintSlowly(string str)
    {
        foreach(var c in str)
        {
            Console.Write(c);
            Thread.Sleep(50);
            //Thread.Sleep(c == '.' ? 400 : 50); //if you want to wait longer at .
        }
        Console.WriteLine();
    }
