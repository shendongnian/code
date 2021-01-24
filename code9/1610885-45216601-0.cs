    public class CustomNamespaceXmlFormatter : XmlMediaTypeFormatter
    {
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
                                                TransportContext transportContext)
        {
            try
            {
                XmlDocument doc = JsonConvert.DeserializeXmlNode(value.ToString(), "myRootElement");
                doc.LoadXml(doc.InnerXml);
                doc.Save(writeStream);
                var tcs = new TaskCompletionSource<object>();
                tcs.SetResult(null);
                return tcs.Task;
            }
            catch (Exception)
            {
                return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            }
        }
    }
