    public static IEnumerable<DestObject> ObjectToObject1(IEnumerable<SourceObject> objects)
    {                
        return data.Select(x => new DestObject() { // Map the attributes });
       
    }
