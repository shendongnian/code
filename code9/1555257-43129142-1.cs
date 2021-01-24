    using System.Collections.Generic;
    
    namespace Controller.Framework
    {
       public static class CSortedDictionaryExtensions
       {
          public static DoSomething<CustomDataType1, CustomDataType2>(this SortedDictionary<CustomDataType1, CustomDataType2> dictionary){
            dictionary.SomeMethod();
          }
          // other methods which work on m_dictionary;
       }
    }
    // Create custom dictionary...
    var dictionary = new SortedDictionary<int, List<string>>();
    dictionary.DoSomething();
