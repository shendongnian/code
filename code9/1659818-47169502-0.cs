    this.MyContext.MyClass
        .GroupBy(x => x.Value)
        .ToList() // need to materialize here
        .ForEach(grp =>
        {
             MyClass itemWithMaxId = grp.FirstOrDefault();
             foreach (MyClass item in grp)
             {
                 if (item.Id > itemWithMaxId.Id)
                 {
                     itemWithMaxId = item;
                 }
             }      
        });
