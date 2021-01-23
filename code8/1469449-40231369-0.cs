         var lst = new string[]
         {
            "Hans",
            "Hannes",
            "Gustav",
            "Klaus",
            "Herbert",
            "Hanne"
         };
         var source = lst.GroupBy(x => x.Substring(0, 2)).OrderByDescending(x => x.Count()).First()
         Console.WriteLine(source.Key);
         Console.WriteLine(string.Join(",", source));
