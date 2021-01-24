    var tableA = from itemA in ctx.tableA
                 let minId = ctx.tableA.Min(x => x.Id)
                 select new { itemA, index = itemA.Id - minId };
    
    var tableB = from itemB in ctx.tableB 
                 let minId = ctx.tableB.Min(x => x.Id)
                 select new { itemB, index = itemB.Id - minId };
    
    var answer = (from itemAA in tableA
                  join itemBB in tableB on itemAA.index equals itemBB.index
                  select new { itemAA.itemA, itemBB.itemB}).ToList().SelectMany(x => {
                      var result = new List<Tuple<Type1, Type2>>();
                      var props1 = x.itemA.GetType().GetProperties().ToList();
                      var props2 = x.itemB.GetType().GetProperties().ToList();
                      for(var i = 0; i < Math.Min(props1.Count, props2.Count); i++)                              
                           result.Add(new Tuple<Type1, Type2>((Type1)props1[i].GetValue(x.itemA), (Type2)props2[i].GetValue(x.itemB)));
                       return result;                                  
                  }).ToList();
