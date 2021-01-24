    Dictionary<int, bool> keys = new Dictionary<int,bool>();
    Dictionary<int, bool> values = new Dictionary<int,bool>();
    string test = "3:44-5:87-1:345";
    var attributes = test.Split(new[] { "-" },
         StringSplitOptions.RemoveEmptyEntries);
    
     if (attributes.Length != 0)
     {
         foreach (var attribute in attributes)
         {
             var attArray = attribute.Split(new[] { ":" },
                 StringSplitOptions.RemoveEmptyEntries);
    
             if (attArray.Length >= 2)
             {
                int key = Convert.ToInt32(attArray[0].ToString())
                int value = Convert.ToInt32(attArray[1].ToString())
    
                if(!keys.Contains(key))
                {
                    keys.Add(key, keyExists(key));
                }
    
                if(!values.Contains(value))
                {
                    values.Add(value, valueExists(value));
                }
    
                if(keys[key])
                {
                   if(values[value])
                   {
                      //CODE here to import data to datatabse
                   }
                }
             }
         }
     }
