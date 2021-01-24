    public static I CreateInstance<I>() where I : class  
    {  
        string assemblyPath = Environment.CurrentDirectory + "\\MyTestClass.exe";  
    
        Assembly assembly;  
      
        assembly = Assembly.LoadFrom(assemblyPath);  
        Type type = assembly.GetType("MyTestClass");  
        return Activator.CreateInstance(type) as I;  
    }
