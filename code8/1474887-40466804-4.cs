    public class HttpPostedFileBaseConverter : JsonConverter
    {
        class HttpPostedFileSurrogate
        {
            public string ContentType { get; set; }
            public string FileName { get; set; }
            public byte[] InputStream { get; set; }
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(HttpPostedFileBase).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var wrapper = (HttpPostedFileWrapper)value;
            // Save position
            var surrogate = new HttpPostedFileSurrogate
            {
                ContentType = wrapper.ContentType,
                FileName = wrapper.FileName,
                InputStream = wrapper.InputStream.ReadAllBytesAndReposition(),
            };
            serializer.Serialize(writer, surrogate);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var surrogate = serializer.Deserialize<HttpPostedFileSurrogate>(reader);
            var file = HttpPostedFileExtensions.ConstructHttpPostedFile(surrogate.InputStream, surrogate.FileName, surrogate.ContentType);
            return new HttpPostedFileWrapper(file);
        }
    }
    public static class HttpPostedFileExtensions
    {
        public static HttpPostedFile ConstructHttpPostedFile(byte[] data, string filename, string contentType)
        {
            // Comes from http://stackoverflow.com/questions/5514715/how-to-instantiate-a-httppostedfile
            // Get the System.Web assembly reference (they seem to be in different assemblies in different versions of .Net
            var assemblies = new[] { typeof(HttpPostedFile).Assembly, typeof(HttpPostedFileBase).Assembly };
            // Get the types of the two internal types we need
            Type typeHttpRawUploadedContent = assemblies.Select(a => a.GetType("System.Web.HttpRawUploadedContent")).Where(t => t != null).First();
            Type typeHttpInputStream = assemblies.Select(a => a.GetType("System.Web.HttpInputStream")).Where(t => t != null).First();
            // Prepare the signatures of the constructors we want.
            Type[] uploadedParams = { typeof(int), typeof(int) };
            Type[] streamParams = { typeHttpRawUploadedContent, typeof(int), typeof(int) };
            Type[] parameters = { typeof(string), typeof(string), typeHttpInputStream };
            // Create an HttpRawUploadedContent instance
            object uploadedContent = typeHttpRawUploadedContent
              .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, uploadedParams, null)
              .Invoke(new object[] { data.Length, data.Length });
            // Call the AddBytes method
            typeHttpRawUploadedContent
              .GetMethod("AddBytes", BindingFlags.NonPublic | BindingFlags.Instance)
              .Invoke(uploadedContent, new object[] { data, 0, data.Length });
            // This is necessary if you will be using the returned content (ie to Save)
            typeHttpRawUploadedContent
              .GetMethod("DoneAddingBytes", BindingFlags.NonPublic | BindingFlags.Instance)
              .Invoke(uploadedContent, null);
            // Create an HttpInputStream instance
            object stream = (Stream)typeHttpInputStream
              .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, streamParams, null)
              .Invoke(new object[] { uploadedContent, 0, data.Length });
            // Create an HttpPostedFile instance
            HttpPostedFile postedFile = (HttpPostedFile)typeof(HttpPostedFile)
              .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, parameters, null)
              .Invoke(new object[] { filename, contentType, stream });
            return postedFile;
        }
    }
