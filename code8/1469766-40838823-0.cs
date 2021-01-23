    public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            using (StreamWriter streamwriter = new StreamWriter(writeStream))
            {
                return streamwriter.WriteAsync("{\"test\":\"test\"}");
            }
        }
