    public sealed class MemoryHttpPostedFile : HttpPostedFileBase
    {
        readonly string contentType;
        readonly string fileName;
        readonly MemoryStream inputStream;
        public MemoryHttpPostedFile(string contentType, string fileName, [JsonConverter(typeof(StreamConverter))] MemoryStream inputStream)
        {
            if (inputStream == null)
                throw new ArgumentNullException("inputStream");
            this.contentType = contentType;
            this.fileName = fileName;
            this.inputStream = inputStream;
        }
        public override int ContentLength { get { return (int)inputStream.Length; } }
        public override string ContentType { get { return contentType; } }
        public override string FileName { get { return fileName; } }
        [JsonConverter(typeof(StreamConverter))]
        public override Stream InputStream { get { return inputStream; } }
        //TODO: implement SaveAs()
        public override void SaveAs(string filename)
        {
            // Implement based on HttpPostedFile.SaveAs()
            // https://referencesource.microsoft.com/#System.Web/HttpPostedFile.cs,678e7f8bc95c149f
            throw new NotImplementedException();
        }
    }
    public class HttpPostedFileBaseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(HttpPostedFileBase).IsAssignableFrom(objectType)
                && !typeof(MemoryHttpPostedFile).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var postedFile = (HttpPostedFileBase)value;
            // Save position
            var wrapper = new MemoryHttpPostedFile(postedFile.ContentType, postedFile.FileName, new MemoryStream(postedFile.InputStream.ReadAllBytesAndReposition()));
            serializer.Serialize(writer, wrapper);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var wrapper = serializer.Deserialize<MemoryHttpPostedFile>(reader);
            return wrapper;
        }
    }
