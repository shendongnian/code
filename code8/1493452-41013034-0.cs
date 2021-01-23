       using System.Reflection;
    
       ...
    
       // Properties; some conditions like property.CanRead && property.CanWrite 
       // can well appear redundant, but since the class is not yours,
       // better be a bit paranoic esp. having run into a bad design 
       var properties = hotel
         .GetType()
         .GetProperties(BindingFlags.Public | BindingFlags.Instance)
         .Where(property => property.CanRead && property.CanWrite) // Not necessary 
         .Where(property => property.Name.StartsWith("Image"))
         .Where(property => property.PropertyType == typeof(Image)); // Not necessary
    
       // Properties' values, i.e. images
       List<Image> list = properties
         .Select(property => property.GetValue(hotel) as Image)
         .Where(image => image != null) // if you want to filter out nulls
         .ToList(); 
