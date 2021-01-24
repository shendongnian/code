    using System.Collections.Generic;
    
    namespace Controller.Framework
    {
       class CSortedDictionary<CustomDataType1, CustomDataType2>
       {
          private SortedDictionary<CustomDataType1, CustomDataType2> m_dictionary;
          // other methods which work on m_dictionary;
       }
    }
    // Create custom dictionary...
    var custom_dictionary = new CSortedDictionary<int, List<string>>();
