    while( (line = reader.ReadLine()) != null) 
    {
        string[] values = line.Split(',');
        if (values.Length < 3)
        {
            Console.Error.WriteLine("Invalid input line: " + line);
            continue;
        }
        string name = values[0];
        int euros;
        if (!int.TryParse(values[1], out euros))
        {
            Console.Error.WriteLine("Invalid euros value in the line: " + line);
            continue;
        }
        int cents;
        if (!int.TryParse(values[1], out cents))
        {
            Console.Error.WriteLine("Invalid cents value in the line: " + line);
            continue;
        }
        Console.WriteLine(euros);
        //Turistai tourists = new Turistai(name, euros, cents);
        amount++;
    }
