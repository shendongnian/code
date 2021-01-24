    using System;
    using System.Collections.Generic;
    using Project.Base.Sub;
    
    namespace Project
    {
      namespace Base
      {
        public class List<T> { }
        namespace Sub { }
        namespace Sub2 
        { 
          public class P
          {
            public static void Main()
            {
              var list = new List<int>(); 
              Console.WriteLine(list.GetType().Namespace);
              Console.Read();
            }
          }
        }
      }
    }
    
