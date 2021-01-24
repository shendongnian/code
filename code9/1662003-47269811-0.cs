    public static void Rename(this JToken token, string newName)
    {
        JProperty property;
        if (token.Type == JTokenType.Property)
        {
            if (token.Parent == null)
                throw new JsonException("The property does not have a parent; cannot rename");
            property = (JProperty)token;
        }
        else
        {
            if (token.Parent == null || token.Parent.Type != JTokenType.Property)
                throw new JsonException("This token's parent is not a JProperty; cannot rename");
            property = (JProperty)token.Parent;
        }
        var newProperty = new JProperty(newName, property.Value);
        property.Replace(newProperty);
    }
