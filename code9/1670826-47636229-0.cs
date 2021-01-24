    while (true)
    {
        String line = Console.ReadLine();
    
        if ((line == null) || (line.ToLowerInvariant() == "stop"))
            break;
    
        // implement your logic here... for example, if you want to print
        // a word at once even if the user entered multiples:
        String[] split = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (Int32 i = 0 ; i < split.Length; ++i)
            Console.WriteLine(split[i]);
    }
