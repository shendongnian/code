        foreach (Property p in item.Properties)
                {
                    if (p.Name == "CopyToOutputDirectory")
                    {
                        p.Value = 1;
                    }
    
                    //dic[p.Name] = p.Value;
                }
   
