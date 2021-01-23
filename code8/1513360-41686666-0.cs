    public class DateTimeConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Date)
            {
                // Json.NET already parsed the date successfully.  Return it.
                return (DateTime)token;
            }
            else
            {
                TimeSpan span;
                if (token.Type == JTokenType.TimeSpan)
                {
                    // Not sure this is actually implemented, see
                    // http://stackoverflow.com/questions/13484540/how-to-parse-a-timespan-value-in-newtonsoft-json/13505910#13505910
                    span = (TimeSpan)token;
                }
                else
                {
                    var timeString = (string)token;
                    if (String.IsNullOrWhiteSpace(timeString))
                        span = new TimeSpan();
                    else
                    {
                        try
                        {
                            span = TimeSpan.Parse(timeString, new DateTimeFormatInfo { LongTimePattern = "HH:mm:ss" });
                        }
                        catch (Exception ex)
                        {
                            throw new ValidationException(ex.Message);
                        }
                    }
                }
                var currentValue = (DateTime?)existingValue ?? SqlDateTime.MinValue.Value;
                // Combine currentValue & TimeSpan and return.  REPLACE THIS WITH YOUR OWN LOGIC.
				// I don't really know what how you want to do this.
                return new DateTime(currentValue.Year, currentValue.Month, currentValue.Day) + span;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
