    public static class KeyValueConfigurationCollectionExtension 
        {
            public static bool ContainsKey<T>(T key)
            {
                System.Collections.Specialized.NameValueCollection coll = new System.Collections.Specialized.NameValueCollection();
    
                string keyValue = key.ToString();
                int upperBound = coll.Count;
                List<string> items = new List<string>();
                for(int i = 0; i < upperBound; i++)
                {
                    items.Add(coll[i].ToString());
                }
    
                int index = items.IndexOf(keyValue);
                if(index >= 0)
                    return true;
    
                return false;
    
            }
        }
