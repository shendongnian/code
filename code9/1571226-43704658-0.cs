    int n = 0;       
    List<string>[] grouping = new List<string>[20];
    while ((line = Console.ReadLine()) != null) 
    {
        if (line == "group"){
            // don't increment "n" yet, since 0 is valid index.
            grouping[n] = new List<string>();        
            n++;
        }
        else 
        {
            grouping[n].Add(line);
        }
    } 
