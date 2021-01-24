    public static string Dictionary_Lookup(input)
        {   //DictionaryLoad.Instance will return the dictionary now. 
            if(DictionaryLoad.Instance.ContainsKey(input))
            {
                string return_string = DictionaryLoad.Instance[input];
                return return_string;
            }else
            {
                return "ERROR";
            }
        }
