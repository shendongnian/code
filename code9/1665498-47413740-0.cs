    string regex = "(?![0-9])(.*)(?=[0-9])";
    string toSplit = "4 Program Files (x86) 2";
    string [] result = Regex.Split(toSplit, regex);
    foreach (string s in result)
    {
        Console.Out.WriteLine(s);
    }
    Console.ReadLine();
