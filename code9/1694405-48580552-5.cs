    void PerformCheck(Type classType, Type interfaceType)
    {
        var methods = interfaceType.GetMethods().Where(m => m.GetParameters().Any(p => p.IsOptional));
        foreach(var method in methods)
        {
           var optionalParameters = method.GetParameters().Where(p => p.IsOptional);
            foreach(var parameter in optionalParameters)
            {
                var classParam = classType.GetMethod(method.Name).GetParameters().FirstOrDefault(p => p.Name == parameter.Name);   
                if(!object.Equals(classParam.DefaultValue, parameter.DefaultValue))
                {
                    Console.WriteLine("method " + method.Name + " has different defaul values on parameter " + parameter.Name);
                }
            }
        }
    }
