    var props = typeof(MyModel).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(x => x.Name.StartsWith("Afbeelding"));
    
    foreach(var prop in props)
    {
      var value = prop.GetValue(modelHere); //now value has the corresponding string.
    }
    
    // Or you can do
    for(int i =1 ; i < 8; i++){
      var neededProp = props.FirstOrDefault(x => x.Name == $"Afbeelding_{i}"); //now this has the value
    }
