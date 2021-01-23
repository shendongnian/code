    private Newtonsoft.Json.Schema.JsonSchema _schema;  
    public static Newtonsoft.Json.Schema.JsonSchema Schema
    {
        get
        {
            if (_schema == null)
            {
                Newtonsoft.Json.Schema.JsonSchemaGenerator generator = new Newtonsoft.Json.Schema.JsonSchemaGenerator();
                _schema = generator.Generate(typeof(DataResponse));
            }
            return _schema;
        }
    }
    ...
    Newtonsoft.Json.Linq.JObject message = Newtonsoft.Json.Linq.JObject.Parse(json); 
    if(Newtonsoft.Json.Schema.Extensions.IsValid(message, DataResponse.Schema))
    {...}
    else if (Newtonsoft.Json.Schema.Extensions.IsValid(message, ServerStatus.Schema))
    {...}
    ...
