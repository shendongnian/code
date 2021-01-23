        private object PopulateObject(object newObject, JsonReader reader, JsonObjectContract contract, JsonProperty member, string id)
        {
            bool finished = false;
            do
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                    {
                        // Read and process the property.
                    }
                    case JsonToken.EndObject:
                        finished = true;
                        break;
                    case JsonToken.Comment:
                        // ignore
                        break;
                    default:
                        throw JsonSerializationException.Create(reader, "Unexpected token when deserializing object: " + reader.TokenType);
                }
            } while (!finished && reader.Read());
            if (!finished)
            {
                ThrowUnexpectedEndException(reader, contract, newObject, "Unexpected end when deserializing object.");
            }
            return newObject;
         }
