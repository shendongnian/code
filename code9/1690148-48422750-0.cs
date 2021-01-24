    List<string> results = new List<string>();
    foreach (string item in ReadLines) 
    {
        if (item == "Start Details") 
        {
            DetailsFound = true;
        }
        else if (item == "End Details") {
            break;
        }
        else if (DetailsFound) 
        {
            Console.WriteLine("Details - " + item);
            results.Add(item);
        }
        
    }
