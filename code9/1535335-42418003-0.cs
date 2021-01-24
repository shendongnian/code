        bool endSet = false;
        int groupCount = 1;
        string group = "";
        StringBuilder outputBuilder = new StringBuilder();
        foreach (string fruit in fruits)
        {
            if (endSet)
            {
                group += fruit;
                outputBuilder.Append(group);
                group = "";
            }
            else
            {
                group += "Group " + (groupCount++).ToString() + fruit + ", ";
            }
        
            endSet = !endSet;
        }
    
        if ((fruits.Count) % 2 == 1)
        {
           outputBuilder.Append(group);
        }
    
        Console.Writeline(outputBuilder.ToString());
