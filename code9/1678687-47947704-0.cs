    public void Validate()
    {
        //...
        JsonSchema schema = JsonSchema.Parse("{'pattern':'lol'}");
        JToken stringToken = JToken.FromObject("pie");
        stringToken.Validate(schema);
