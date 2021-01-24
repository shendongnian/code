    var itemsWithMaxIdByGroup = this.MyContext.MyClass
        .GroupBy(x => x.Value)
        .ToList() // need to materialize here
        .Select(grp =>
        {
             MyClass itemWithMaxId = grp.First();
             foreach (MyClass item in grp.Skip(1))
             {
                 if (item.Id > itemWithMaxId.Id)
                 {
                     itemWithMaxId = item;
                 }
             }  
             return itemWithMaxId;    
        });
