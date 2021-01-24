    Tuple<int, int> least = new Tuple<int, int>(-1, -1), most = new Tuple<int, int>(-1, -1);
    List<int> arr = new List<int> { 2, 2, 2, 2, 3, 3, 4, 4, 5, 6, 6 };
    var grp = arr.GroupBy(x => x).Select(x=>x).ToList();
                
    foreach (var item in grp)
    {
        if (least.Item2 == -1 || least.Item2>item.Count())
        {
            var x = new Tuple<int, int>(item.Key, item.Count());
            least = x;
        }
    
        if (most.Item2 == -1 || most.Item2 < item.Count())
        {
            var x = new Tuple<int, int>(item.Key, item.Count());
            most = x;
        }
    }
    
    Console.WriteLine("Least : "+least.Item1+" repeated " + least.Item2+"times");
    Console.WriteLine("Most : "+most.Item1 + " repeated " + most.Item2 + "times");
