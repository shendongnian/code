    {
        public class DictionaryLines
        {
    
            private Dictionary<string, string> line1dictionary;
            private Dictionary<string, string> line2dictionary;
    
            public Dictionary<string, string> Line1Dictionary { get { return line1dictionary; } }
    
            public Dictionary<string, string> Line2Dictionary { get { return line2dictionary; } }
    
            public DictionaryLines()
            {
                line1dictionary = new Dictionary<string, string>();
                line2dictionary = new Dictionary<string, string>();
    
    
                line1dictionary.Add("A1", "Miyapur");
                line1dictionary.Add("A2", "JNTU College");
                line1dictionary.Add("A3", "KPHB Colony");
                line1dictionary.Add("A4", "Kukatpally");
                line1dictionary.Add("A5", "Balanagar");
                line1dictionary.Add("A6", "Moosapeta");
                line1dictionary.Add("A7", "Bharath nagar");
                line1dictionary.Add("A8", "Erragadda");
    
    
                line2dictionary.Add("B1", "JBS");
                line2dictionary.Add("X3", "Parade Grounds");
                line2dictionary.Add("B3", "Secundrabad");
                line2dictionary.Add("B4", "Gandhi Hospital");
               }
    }
