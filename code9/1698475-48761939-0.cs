     public static class CustomTypeExtensions {
       private static Dictionary<CustomType, Type> s_Map = new Dictionary<CustomType, Type>() {
         {CustomType.Datetime,  typeof(DateTime)},
         {CustomType.Date, typeof(DateTime}, 
         ...
       }; 
        
       public static Type ToType(this CustomType value) {
         if (s_Map.TryGetValue(value, out var result))
           return result;
         else
           return typeof(string); // when not found, return string 
       }
     }
....
    var custom = CustomType.Bittype;
    ...
    Type t = custom.ToType();   
