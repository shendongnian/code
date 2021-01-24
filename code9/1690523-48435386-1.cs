    public static class EnumEx
    {
       public static T GetValueFromTerms<T>(string value)
       {
          var type = typeof(T);
          if (!type.IsEnum)
          {
             throw new InvalidOperationException();
          }
    
          foreach (var field in type.GetFields())
          {
             if (Attribute.GetCustomAttribute(field, typeof(TermsAttribute)) is TermsAttribute attribute)
             {
                // Search your attribute array or properties here
                // Depending on the structure of your attribute 
                // you will need to change this if Conidition
                if (attribute.ContainsTerms(value))
                {
                   return (T)field.GetValue(null);
                }
             }
             else
             {
                if (field.Name == value)
                {
                   return (T)field.GetValue(null);
                }
             }
          }
          throw new ArgumentException("Not found.", nameof(value));
          // or return default(T);
       }
    }
