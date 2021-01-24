     private static void GetPropertyValues(Object obj)
       {
          Type t = obj.GetType();
          Console.WriteLine("Type is: {0}", t.Name);
          PropertyInfo[] props = t.GetProperties();
          Console.WriteLine("Properties (N = {0}):", 
                            props.Length);
          foreach (var prop in props)
             if (prop.GetIndexParameters().Length == 0)
                Console.WriteLine("   {0} ({1}): {2}", prop.Name,
                                  prop.PropertyType.Name,
                                  prop.GetValue(obj));
             else
                Console.WriteLine("   {0} ({1}): <Indexed>", prop.Name,
                                  prop.PropertyType.Name);
    
       }
