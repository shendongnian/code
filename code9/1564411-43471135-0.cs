        public bool ValidateMissingDoubleQuotes(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                while (reader.Read())
                {
                    return !(reader.TokenType == JsonToken.PropertyName && reader.QuoteChar != '\"');
                }
            }
            return true;
        }
