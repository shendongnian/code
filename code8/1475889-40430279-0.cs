    public class IPByteArrayConverter : JsonConverter
    {
        private static string ConvertIPByteArraytoString(byte[] ip)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(ip[0]);
            for (int i = 1; i < ip.Length; i++)
            {
                builder.Append(".");
                builder.Append(ip[i]);
            }
            return builder.ToString();
        }
        private static byte[] ConvertIPStringToByteArray(string ip)
        {
            var blah = new byte[4];
            var split = ip.Split('.');
            if (split.Length != 4)
            {
                //Log.Error("IP Address in settings does not have 4 octets.Number Parsed was {NumOfOCtets}", split.Length);
                //throw new SettingsParameterException($"IP Address in settings does not have 4 octets. Number Parsed was {split.Length}");
            }
            for (int i = 0; i < split.Length; i++)
            {
                if (!byte.TryParse(split[i], out blah[i]))
                {
                    //var ex = new SettingsParameterException($"Octet {i + 1} of {ParameterName} could not be parsed to byte. Contained \"{split[i]}\"");
                    //Log.Error(ex,"Octet {i + 1} of {ParameterName} could not be parsed to byte. Contained \"{split[i]}\"", i, ParameterName, split[i]);
                    //throw ex;
                }
            }
            return blah;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Bytes)
                return (byte[])token;
            return ConvertIPStringToByteArray((string)token);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var bytes = (byte[])value;
            writer.WriteValue(ConvertIPByteArraytoString(bytes));
        }
    }
