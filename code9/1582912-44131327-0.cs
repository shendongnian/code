    var dict = new Dictionary<int, List<Price>>();
    parsedList.ForEach(pl => {
         if(!dict.ContainsKey(pl[0], new List<Price>())) {
              dict.Add(pl[0]);
         }
         
         dict[pl[0]].Add(new Price { CategoryId = pl[1], Price = pl[2] });
    });
