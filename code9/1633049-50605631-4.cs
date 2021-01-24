     public class Proxy : MarshalByRefObject
     {
            public Assembly GetAssembly(string assemblyPath)
            {
                try
                {
                    return Assembly.Load(AssemblyName.GetAssemblyName(assemblyPath));
                }
                catch (Exception)
                {
                    return null;
                }
            }   
    } 
