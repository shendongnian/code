    TDictionary<string, DateTime> runningCode = new TDictionary<string,DateTime>();
    
    ...
    
        if(runningCode.AddIfNotExists("MyCodeDescriptor", DateTime.Now()))
        {
           Task.Run(async() => 
           {
               PostValues();
               runningCode.Remove("MyCodeDescriptor");
           });
        }
