      public class product_new : NK.Objects._product_new {
        // Simplest, but not thread safe; use ConcurrentDictionary for thead safe version
        private static Dictionary<int, int> s_KnownAnswers = new Dictionary<int, int>();
 
        // Lazy: do not execute expensive operation eagerly: in the constructor;
        // but lazyly: in the property where we have to perform it
        public int CountOP {
          get {
            int result = 0;
            
            // do we know the answer? If yes, then just return it
            if (s_KnownAnswers.TryGetValue(Count_Per_Page, out result)) 
              return result;
            // if no, ask RDMBS
            result = number_of_pages(Count_Per_Page);
            // and store the result as known answer
            s_KnownAnswers.Add(Count_Per_Page, result); 
            return result;
          }
       }
        ...
      }
