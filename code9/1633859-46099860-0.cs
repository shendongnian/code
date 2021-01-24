    public abstract class Base_Setter
    {
      public Base_Setter() { }
    
      public Base_Setter(string overrideValue)
      {
        var properties = this.GetType().GetProperties();
        foreach (var property in properties)
        {
          if(property.PropertyType == typeof(string))
          {
            property.SetValue(this, overrideValue);
          }
        }
      }
    }
