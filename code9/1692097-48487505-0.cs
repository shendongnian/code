    string[] abc = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
    string x = "1g";
    string y = "2b";
    
    string strx = Regex.Match(x, @"\d+").Value;
    string stra = Regex.Match(x, @"[a-z]+").Value;
    int intx = Int32.Parse(strx);
    
    string stry = Regex.Match(y, @"\d+").Value;
    string strb = Regex.Match(x, @"[a-z]+").Value;
    int inty = Int32.Parse(stry);
    
    Console.WriteLine(strx);
    Console.WriteLine(stra);
    Console.WriteLine("----");
    
    int len = inty - intx + 1;
    List<string> xycombinations = new List<string>();
    string[] ycombinations = new string[] { };
    if (len >= 0)
    {
        int starting = 0;
        while (abc[starting] != stra)
        {
            starting = starting + 1;
        }
        while (starting < abc.Length)
        {
            xycombinations.Add(intx.ToString() + abc[starting]);
            starting = starting + 1;
        }
        for (int i = 0; i < xycombinations.Count; i++)
        {
            Console.WriteLine(xycombinations[i]);
        }
    }
                
    Console.ReadLine();
