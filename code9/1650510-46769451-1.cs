    PropertyInfo[] infos = yourObjectInstance.GetType().GetProperties();            
    int count = 0;
    
    for(int i = 0; i < infos.Length; i++)
    {
        if(infos[i].Name == "YourStringPropertyName")
        {
            string body = infos[i].GetValue(yourObjectInstance).ToString().Trim();
    
            if(!string.IsNullOrEmpty(body))
            {
                count++;
                Console.WriteLine(body.Length);
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
