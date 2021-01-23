    using System.Reflection;
    ...
    private void someMethod(string myTypeString, List<Values> typeList)
    {
        PropertyInfo pi = typeof(Values)
          .GetProperty(myTypeString,
             System.Reflection.BindingFlags.Instance | 
             System.Reflection.BindingFlags.NonPublic | // private/internal/protected  
             System.Reflection.BindingFlags.Public);
    
        // property exists and returns DateTime
        if (null == pi)
          return; // or throw exception
        else if (pi.PropertyType != typeof(DateTime))
          return; // or throw exception
    
        foreach(var type in typeList
          .Where(x => (DateTime) (pi.GetValue(x, null)) > DateTime.Now))
        {
            //do my loop
        }
    }
