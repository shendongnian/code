    var result = new List<SomeModel>();
    foreach (var response in someResponse)
    {
        // Select(converter)
        var conversion = converter(response);
        
        // Where(conversion => conversion.Status == ConversionStatus.Success)
        if (conversion.Status == ConversionStatus.Success)
        {
            // Select(conversion => conversion.Object)
            var value = conversion.Object;
            
           // Cast<SomeModel>()
            var model = (SomeModel)value;
  
            result.Add(model);
        }
    }
    return result;
