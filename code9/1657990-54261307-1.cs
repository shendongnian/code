     public IEnumerable<Parent>GetAllParents()
     {
          return context.parents..Select(p=> new Parent 
          {
           Id = p.Id,
           TotalPrice = p.Children.Sum(x=>x.UnitePrice)
          });
    } 
