    PropertyInfo[] infos = yourObjectInstance.GetType().GetProperties();            
    int count = 0;
    
    for(int i = 0; i < infos.Length; i++)
    {
        if(infos[i].PropertyType == typeof(string))
        {
            string stringValue = infos[i].GetValue(yourObjectInstance).ToString().Trim();
    
            if(!string.IsNullOrEmpty(body))
            {
                count++;
            }
    
            continue;
        }
    
        if(infos[i].GetValue(yourObjectInstance) != null)
        {                    
            count++;
        }
    }
    
    if(count == 0)
    {
        // Handle error
    }
    
    // Create record
