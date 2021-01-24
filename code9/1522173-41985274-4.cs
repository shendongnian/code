    public class MicrosoftSecondsDateTimeConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.String)
            {
                var s = ((string)token).Trim();
                if (s.StartsWith("/Date(", StringComparison.Ordinal) && s.EndsWith(")/", StringComparison.Ordinal))
                {
                    // MS datetime format is in milliseconds as is shown here:
                    // https://msdn.microsoft.com/en-us/library/bb299886.aspx#intro_to_json_sidebarb
                    // But our times are offsets in seconds.
                    // Convert.
                    var sb = new StringBuilder("\"\\/Date(");
                    var insert = "000"; // Seconds to MS
                    for (int i = 6; i < s.Length - 2; i++)
                    {
                        if (s[i] == '-' || s[i] == '+') // Time zone marker
                        {
                            sb.Append(insert);
                            insert = string.Empty;
                        }
                        sb.Append(s[i]);
                    }
                    sb.Append(insert);
                    sb.Append(")\\/\"");
                    s = sb.ToString();
                    var dt = new JsonSerializer().Deserialize(new StringReader(s), objectType);
                    return dt;
                }
            }
            // Not a Microsoft date.
            return new JsonSerializer().Deserialize(token.CreateReader(), objectType);
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
