        public  class Cars
        {
           string Name { get; set; }   
        }
    
        public class SortByName : IComparer<Cars>
        {    
          public int Compare(Cars first, Cars next)
             {
               return first.Name.CompareTo(next.Name);
             }
         }
