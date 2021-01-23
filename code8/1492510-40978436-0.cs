    public class MyClass
    {
         public string Name {get; set;}
         public int Number {get; set;}
         [JsonProperty("PhotoUrl")] //Notice how this is different from the property name?
         public string PhotoURL {get; set;}
         //...
    }
