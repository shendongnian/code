    var methods = typeof(ValuesController).GetMethods();
    string infoString = "";
    
    foreach(var method in methods)
    {
        // Only public methods that are not constructors
        if(!method.IsConstructor && method.IsPublic)
        {
            // Don't include inherited methods
            if(method.DeclaringType == typeof(ValuesController))
            {
    
                infoString += method.Name;
    
                if(Attribute.IsDefined(method, typeof(System.Web.Http.HttpGetAttribute)))
                {
                    infoString += " GET ";
                }
                if(Attribute.IsDefined(method, typeof(System.Web.Http.HttpPostAttribute)))
                {
                    infoString += " POST ";
                }
    
    
                infoString += Environment.NewLine;
            }
        }
    }
