        string[] linedata = line.Split(charSeparators, StringSplitOptions.None);
        foreach (string line in linedata)
        {
            Console.Write("<{0}>", line);
        }
        Console.Write("\n\n");
