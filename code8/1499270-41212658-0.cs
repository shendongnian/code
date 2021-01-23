    int[] BinaryTable = new int[] { 1101 };
    List<int[]> allItems = new List<int[]>();
    foreach (var item in BinaryTable)
    {
        var items = item.ToString().Select(y => int.Parse(y.ToString())).ToArray();
        allItems.Add(items);
    }
    
    var final = allItems.SelectMany(x => x).ToArray();
           
