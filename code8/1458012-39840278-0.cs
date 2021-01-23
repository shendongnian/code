    List<int> data = new List<int> { 1, 1, 1, 2, 2, 3, 3, 3, 4 };
    var triples = data.GroupBy(x => x)
                      .Where(g => g.Count() > 2)
                      .Select(y => y.Key);
    foreach(var item in triples)
    {
       Debug.Write(item);
    }
