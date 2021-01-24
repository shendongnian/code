      public class product_new : NK.Objects._product_new {
        // Simplest, but not thread safe; use ConcurrentDictionary for thead safe version
        private static Dictionary<int, int> s_KnownAnswers = new Dictionary<int, int>();
 
        public int CountOP {
          get {
            int result = 0;
            
            if (s_KnownAnswers.TryGetValue(Count_Per_Page, out result)) 
              return result;
            result = number_of_pages(Count_Per_Page);
            s_KnownAnswers.Add(Count_Per_Page, result); 
            return result;
          }
        ...
      }
