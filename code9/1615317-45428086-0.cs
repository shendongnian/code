    public ActionResult Save(PersonModel person)
    {
        // Get the models property names
        var modelProperties = person.GetType().GetProperties().Select(x => x.Name);
       // Read the InputStream
        StreamReader reader = new StreamReader(Request.InputStream);
        reader.BaseStream.Position = 0;
        string jsonText = reader.ReadToEnd();
        // Deserialize to object and read property names
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        object jsonObject = serializer.DeserializeObject(jsonText);
        IDictionary<string, object> dictionary = jsonObject as IDictionary<string, object>;
        var jsonProperties = jsonObject.Keys;
        // Get the json property names which do not match the model property names
        List<string> invalidProperties = jsonProperties.Except(modelProperties, StringComparer.OrdinalIgnoreCase).ToList();
