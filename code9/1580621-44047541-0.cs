    List<string> list= new List<string>()
    {
        "Samsung galaxy s8 1200 mAh",
        "Samsung galaxy s8 1200 mAh",                
        "Samsung galaxy s7 1200 mAh",
        "Samsung galaxy s7 1200 mAh",
        "Samsung galaxy s6 1200 mAh"
    };
    List<string> negativePhrs= new List<string>(){"s7","s8"};
    list = list.Where(x=> !negativePhrs.Any(y=> x.ToLower().Contains(y.ToLower()))).ToList();
    foreach(var a in list)
    {
        Console.WriteLine(a);
    }
