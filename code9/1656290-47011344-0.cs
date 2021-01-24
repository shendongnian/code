    namespace SpringNet.FactoryContext
    {
       public class CreateInstance
       {        
         public Object GetClass(string assemblyName,string className)
         {
            return Activator.CreateInstance(assemblyName, className);
         }
       }
    }
