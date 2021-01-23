    while( (line = reader.ReadLine()) != null) 
    {
        string[] values = line.Split(',');
        if (values.Length < 3)
        {
            Console.Error.WriteLine("Invalid input line: " + line);
            continue;
        }
        string name = values[0];
        int euros = int.Parse(values[1]);
        int cents = int.Parse(values[2]);
        Console.WriteLine(euros);
        //Turistai tourists = new Turistai(name, euros, cents);
        amount++;
    }
