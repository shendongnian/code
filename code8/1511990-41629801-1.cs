    public class MyClass
    {
        ...
       [JsonConverter(typeof(OnlyDateConverter))]
       public DateTime MyDate{get;set;}
       ...
    }
