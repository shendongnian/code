    Tuple<int, int> least = new Tuple<int, int>(-1, -1), most = new Tuple<int, int>(-1, -1);
    List<int> arr = new List<int> { 2, 2, 2, 2, 3, 3, 4, 4, 5, 6, 6 };
    var grp = arr.GroupBy(x => x).OrderBy(x=>x.Count()).Select(x => x.Key).ToList();
    Console.WriteLine("Least : "+ grp.First());
    Console.WriteLine("Most : "+ grp.Last());
