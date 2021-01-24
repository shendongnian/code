    var itemsWithMaxIdByGroup = this.MyContext.MyClass
        .GroupBy(x => x.Value)
        .ToList() // need to materialize here
        .Select(grp =>
        {
             MyClass itemWithMaxId = grp.FirstOrDefault();
             foreach (MyClass item in grp)
             {
                 if (item.Id > itemWithMaxId.Id)
                 {
                     itemWithMaxId = item;
                 }
             }  
             return itemWithMaxId;    
        })
        .Where(i => i != null); // Remove nulls coming from empty groups
