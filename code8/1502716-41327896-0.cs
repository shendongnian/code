    var s = "['2016-05-10T13:51:20Z', '2016-05-10T13:51:20+00:00']";
    using (JsonReader jsonReader = new JsonTextReader(new StringReader(s))) {
     jsonReader.DateParseHandling = DateParseHandling.None;
     var array = JArray.Load(jsonReader);
    foreach (var item in array) {
     var itemValue = item.Value<string>();
    Console.WriteLine(itemValue);}
    }
