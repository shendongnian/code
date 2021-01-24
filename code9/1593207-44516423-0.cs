    int[] res = { 1,1,2,2,3,4,4,4};
                
    var words = res.AsEnumerable().GroupBy(x => x);
    foreach (var x in words)
     {
    Console.WriteLine(x.Key+"-"+x.Count());
     }
