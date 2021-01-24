    public abstract class Base_Setter
    {
      public Base_Setter() { }
    
      public Base_Setter(string overrideValue)
      {
        foreach (var property in GetType().GetProperties())
        {
          if(property.PropertyType == typeof(string))
          {
            property.SetValue(this, overrideValue);
          }
        }
      }
    }
