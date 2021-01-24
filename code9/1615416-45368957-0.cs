    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    
    [JsonConverter(typeof(StringEnumConverter))]
    public SomeEnum FooBar {get;set;}
