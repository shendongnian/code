     var stringLists = new List<string>[3]
     {
        new List<string> {"a", "b", "c"},
        new List<string> {"e", "b", "c"},
        new List<string> {"a", "b", "c"}
     };
     var prt = new List<List<string>>();
     foreach (var item in stringLists)
     {
         if(prt.All(it => it.Count != item.Count || it.Except(item).Any()))
              prt.Add(item);
     }
