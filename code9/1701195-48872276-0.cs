    String numbers = "1,2,3";
    
    var intNumbers = new List<int>();
    
    foreach (var item in numbers.Split(','))
    {
        int i;
        if (int.TryParse(item, out i))
            intNumbers.Add(i);
    }
                
    if (intNumbers.Any(i => i >=1 || i <= 3))
    {
        // Found!
    }
