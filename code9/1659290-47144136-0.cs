    static class Listutils 
    {
         public static List<T> Shrink<T>(List<T> src, Predicate<T> predicate) 
         {
             if (src == null || src.Count == 0) 
                  return null;
             List<T> newList = new List<T>();
             foreach(T item in src) 
             {
                if (predicate(item))
                           newList.Add(item);   
             }
             return newList;
         }
    }
    ........somewhere in your program 
      List<string> list = new List<string>{"Cat","Dog","Bird","Badger","Snake"};
      
      // select only Cat, Dog and Bird
      List<string> shrinked = ListUtils.Shrink(list, (name) => delegate 
      {
         return (name == "Cat" || name == "Dog" || name == "Bird");
      });
  
 
