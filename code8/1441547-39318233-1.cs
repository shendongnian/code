    try
    {
        Console.WriteLine("Ready ...");
        var cmd = Console.ReadLine();
        if (cmd == "e")
        {
            throw new Exception("boom");
        } else
        {
            Console.WriteLine("success!");
        }
        Environment.ExitCode = 0;
    }
    catch(Exception e)
    {
        // write to stderr
        Console.Error.WriteLine(e.Message);
        // exit code to 1
        Environment.ExitCode = 1;
    }
