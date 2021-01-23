    List<double> input = new List<double>{9,77,5,5,31};
    
    var dict = new Dictionary<double, int>();
    
    foreach (var item in input)
    {
        if(dict.ContainsKey(item))
        {
            dict[item]++;
        }
        else
        {
            dict[item] = 1;
        }
    }
    
    foreach (var item in dict)
    {
    	if (item.Value > 1)
    		Console.Write("{0}*{1}", item.Key, item.Value);
    	else
            Console.Write(item.Key);
    	Console.Write(" ");
    }
