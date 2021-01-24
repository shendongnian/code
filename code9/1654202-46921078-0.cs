    var testObj = new Newtonsoft.Json.Linq.JObject();
 
    if (testObj.TryGetValue("player", out Newtonsoft.Json.Linq.JToken token)) {
     var yourString = token.Value<string>("FirstName"); // can be null
     var yourNullableInt = token.Value<int?>("AnyNumber"); // can be null
     var yourInt = token.Value<int?>("AnyNumber") ?? 0; // can be 0 if null
    }
