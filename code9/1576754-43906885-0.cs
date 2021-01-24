    List<List<decimal>> list= new List<List<decimal>>();
    list.Add(new List<decimal>(){ 1.501M,2.231M,3M});
    list.Add(new List<decimal>(){ 4.505M,5M,3M});
    list.Add(new List<decimal>(){ 1M,7M,8M});
    var result = list.Select(x=>x.Select(y=>Math.Round(y,2)).ToList()).ToList();
    foreach(var a in result)
    {
        foreach(var b in a)
        {
            Console.Write(b + "\t");
        }
        Console.WriteLine();
    }
