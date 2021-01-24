    if (speed < KB)
    {
        Console.WriteLine("{0} Byte", speed);
    }
    else
    {
        if (speed < 100)
        {
            Console.WriteLine("{0} KB/S", speed);
        }
        else if (speed < 1000)
        {
            Console.WriteLine("{0} MB/S", speed);
        }
        else if (speed < 10000)
        {
            Console.WriteLine("{0} GB/S", speed);
        }
        else 
        {
            Console.WriteLine("{0} TB/S", speed);
        }
    }
