    public genericInsert<T>(T linqObj, string opJsonRequired) {
         linqObj.LoadFromJson(opJsonRequired);
         linqObj.save(dbContext);
    }
    public static class LinqObjectExtensions 
    {
       public static T LoadFromJson(this T source, string opJsonRequired) where T : 'SomeType' {
           JsonSerializer serializer = new JsonSerializer();
           var operation = ('SomeType')serializer.Deserialize(opJsonRequired);
           ...do operation to T  
           return T;
    }
