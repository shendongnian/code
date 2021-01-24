    private bool Get<T>(IEnumerable<T> list, Type someType) 
    {
       foreach (var item in list)
       {
          if (item.GetType()
                   .GetGenericTypeDefinition() == someType)
          {
             return true;
          }
       }
       return false;
    }
    
    private List<T> Get2<T>(IEnumerable<T> list, Type someType)
    {
       return list.Where(
             item => item.GetType()
                         .GetGenericTypeDefinition() == someType)
          .ToList();
    }}
