    object[] RA= {"Ram",123,122};
    for(int idx = 0; idx < RA.Length; idx++)
    {
        switch(RA[idx])
        { 
            case string s:
                Console.WriteLine($"The type of {s} is string");
                break;
            case int i:
                Console.WriteLine($"The type of {i} is int");
                break;
            default:
                Console.WriteLine($"The type of {RA[idx]} is {RA[idx].GetType().Name}");
                break;
        }
    }
