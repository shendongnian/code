    int?[] list1 = {0,1,2,3,4};
    int?[] list2 = {2,3,4,5};
    int?[] list3 = {3,4};
    var result = new []{ list1, list2, list3 }.Merge();
    
    Console.WriteLine(string.Join(Environment.NewLine, result.Select(t=>string.Join(",", t))));
