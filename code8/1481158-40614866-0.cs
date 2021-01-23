    public string ValidateProperty<T>(T parameter)
    {
         var properties = typeof(...).GetProperties();
         foreach(var property in properties)
              if(property == parameter)
                  return "OK";
    
         return "FAIL";
    }   
    var content = collection.Get().Where(property => ValidateProperty(property.Name.Value) == "OK" && ValidateProperty(property.State.Value) == "OK");
