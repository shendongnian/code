        private List<CreatorPropertyContext> ResolvePropertyAndCreatorValues(JsonObjectContract contract, JsonProperty containerProperty, JsonReader reader, Type objectType)
        {
            List<CreatorPropertyContext> propertyValues = new List<CreatorPropertyContext>();
            bool exit = false;
            do
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        // Read and process the property.
                        break;
                    case JsonToken.Comment:
                        break;
                    case JsonToken.EndObject:
                        exit = true;
                        break;
                    default:
                        throw JsonSerializationException.Create(reader, "Unexpected token when deserializing object: " + reader.TokenType);
                }
            } while (!exit && reader.Read());
            return propertyValues;
        }
