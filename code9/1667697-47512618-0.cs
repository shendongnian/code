    public class Test
    {
        public int ID{get;set;}
        public int Name{get;set;}
        public int Type{get;set;}
        public Dictionary<string,string> XML{get;set;}
    
        // this class handles comparing a type that has a dictionary of strings
        private class Comparer: IComparer<Test>
        {
            string _key;
            // key is the keyvalue from the dictionary we want to compare against
            public Comparer(string key) 
            {
                _key=key;
            }
            
            public int Compare(Test left, Test right) 
            {
                // let's ignore the null cases,
                if (left == null && right == null)  return 0;
                string leftValue;
                string rightValue;
                // if both Dictionaries have the key we want to sort on ...
                if (left.XML.TryGetValue(_key, out leftValue) && 
                    right.XML.TryGetValue(_key, out rightValue)) 
                {
                    // ... lets compare on those values
                    return leftValue.CompareTo(rightValue);     
                }
                return 0;
            }
        }
          
        // this method gives you an Instace that implements an IComparer
        // that knows how to handle your type with its dictionary
        public static  IComparer<Test> SortOn(string key)
        {
            return new Comparer(key);
        }
    }
