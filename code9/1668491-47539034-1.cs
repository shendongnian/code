    protected virtual void ConfigureFormatter(HttpConfiguration config)
            {
                JsonConvert.DefaultSettings = () =>
                {
                    JsonSerializerSettings result = new JsonSerializerSettings();
    
                    //Include the type name to be able to deserialize into the derived instead of the base type.
                    result.TypeNameHandling = TypeNameHandling.Auto;
    
                    //Do not include null properties in serialized JSON.
                    result.NullValueHandling = NullValueHandling.Ignore;
        
                    return result;
                };
    
                JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
                jsonFormatter.SerializerSettings = JsonConvert.DefaultSettings();
                config.Formatters.Clear();
                config.Formatters.Add(jsonFormatter);
    
                config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));
            }
