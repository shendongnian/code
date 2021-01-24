    public class MailAddressConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mailAddress = value as MailAddress;
            writer.WriteValue(mailAddress == null? string.Empty : mailAddress.ToString());
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var text = reader.Value as string;
            MailAddress mailAddress;
            return IsValidMailAddress(text, out mailAddress) ? mailAddress : null;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MailAddress);
        }
        private static bool IsValidMailAddress(string text, out MailAddress value)
        {
            try
            {
                value = new MailAddress(text);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }
    }
