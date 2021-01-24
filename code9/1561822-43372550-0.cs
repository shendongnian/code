    static void Main()
    {
        //var lines = File.ReadLines(file).ToList();
        // this is just a fast generation for sample data
        var lines = Enumerable.Range(0, 500000)
                                .Select(i => string.Join(",", i % 7, i, i & 2))
                                .ToList();
        // HashSet will work as an indexed store and will match faster in your loop
        var distinctMarketIds = new HashSet<string>{
            "0", "2", "3", "5"
        };
        // Do this if you are to use the method syntax instead of the query syntax
        // var newList = lines.Select(l=>l.Split(','))
        //                    .Where(ps=>distinctMarketIds.Contains(ps[0]));
        var newList = from l in lines
                      // this will parse the string once versus twice as you were doing before
                      let ps = l.Split(',')
                      where distinctMarketIds.Contains(ps[0])
                      select ps;
        // can't see the content of your `StoreValues` method but writing to a 
        //    file in parallel will never work as expected.  
        using (var stream = new StreamWriter("outfile.txt"))
            foreach (var l in newList)
                stream.WriteLine(string.Join(";", l));
    }
