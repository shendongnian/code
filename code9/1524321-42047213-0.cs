    public class Factory
    {
       MyObject CreateMyObject(object source)
       {
        var target = new MyObject();
        CopyPropertiesFromSource(target, source):
        return target;
       }
    
    static void CopyPropertiesFromSource(MyObject target, object source)
    {
        var propertiesToInitialize = typeof(MyObject).GetProperties();
        var sourceProperties = source.GetType().GetProperties();
        foreach(var property in propertiesToInitialize)
        {
          var correspondingProperty = sourceProperties.FirstOrDefault(x => x.Name == property.Name && x.PropertyType == property.PropertyType);
    
        if(correspondingProperty == null)
           continue;
    
          property.SetValue(target, correspondingProperty.GetValue(source));
        }
      }
    }
var myClassInstance = new Factory().CreateMyObject({ MyPropertyA = "blah" });
