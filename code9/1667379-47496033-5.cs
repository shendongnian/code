    long count =0;
    string x = "";
    string y = "";
     
    foreach (var i in Enumerable.Range(1, 100000000))
    {
        var s = i.ToString();
    
        foreach (char t in s)
        {
            if (t == '2')
                count++;
        }
    }
    
    Console.WriteLine(count);
