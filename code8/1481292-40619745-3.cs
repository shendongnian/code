    public override Task WriteToStreamAsync(ISerializer serializer, Type type, object value, Stream stream, HttpContent content, TransportContext transportContext)
    {
        var newType = GetNewType(type);
        var newValue = GetNewValue(value, type);
        return Task.Factory.StartNew(() => {
            using (var streamWriter = new StreamWriter(stream, _encoder)) {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(streamWriter, newValue, ns);
            }
        });
    }
