    //First, convert in JObject 
    var o = JsonConvert.DeserializeObject<JObject>(input);
    //Then check if the property error exists
    if(o.Property("error") != null);
    {
         throw new Exception(...)      
    }
    //Finally convert the object
    return o.ToObject<T>();
