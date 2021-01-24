    int n = -1;       
    List<string>[] grouping = new List<string>[20];
    while ((line = Console.ReadLine()) != null) 
    {
        if (line == "group"){
            n++;
            grouping[n] = new List<string>();        
        }
        else 
        {
            grouping[n].Add(line);
        }
    } 
