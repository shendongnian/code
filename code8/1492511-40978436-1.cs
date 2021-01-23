    public class MyClass
    {
         public string Name {get; set;}
         public int Number {get; set;}
         [JsonProperty("PhotoUrl")] //Notice how this is different from the property name?
                                    //This is because the property needs to fit exactly with the json string.
         public string PhotoURL {get; set;}
         //...
    }
