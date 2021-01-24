    var reader = new StreamReader(HttpContext.Current.Request.InputStream);
    var content = reader.ReadToEnd();
    var jObj = (JObject)JsonConvert.DeserializeObject(content);
                
    foreach (JToken token in jObj.Children())
    {
        if (token is JProperty)
        {
            var prop = token as JProperty;
    
            if (prop.Name.Equals("skipExternal") && prop.Value.ToString().Equals("True"))
            {
                // Logic...
            }
        }
    }
