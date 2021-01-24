    public class NoDuplicatesList<T> : List<T>
    {
          public override Add(T Item) 
          {
             if (!Contains(item))
                    base.Add(item);
          } 
    }
