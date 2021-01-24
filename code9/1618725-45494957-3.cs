    public sealed class SerializerSettings : JsonSerializerSettings
    {
        public SerializerSettings() : base()
        {
            this.Converters.Add(new MailAddressConverter());
        }
    }
