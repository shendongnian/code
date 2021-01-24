    using System.Collections.Generic;
    
    namespace Controller.Framework
    {
       class CSortedDictionary<CustomDataType1, CustomDataType2>: SortedDictionary<CustomDataType1, CustomDataType2> 
       {
          // other methods which work on m_dictionary;
       }
    }
    // Create custom dictionary...
    var custom_dictionary = new CSortedDictionary<int, List<string>>();
