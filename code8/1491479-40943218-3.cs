    var input = new List<double> { 9, 77, 5, 5, 31 };
    var dict = new Dictionary<double, int>();
    var listAsString = new StringBuilder();
    
    foreach (var item in input)
    {
        if (dict.ContainsKey(item))
            dict[item]++;
        else
            dict[item] = 1;
    }
    
    foreach (var item in dict)
    {
        listAsString.Append(item.Value > 1 ? $"{item.Value}*{item.Key} " : $"{item.Key} ");
    }
    
    Console.WriteLine(listAsString);
