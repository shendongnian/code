    // Wrap "String" in a container class
    public class JsonStringWrapper
    {
        // Hey Microsoft - This is where it would be nice if "String" wasn't marked "sealed"
        public string theString { get; set; }
        public JsonStringWrapper() { }
        public JsonStringWrapper(string stringToWrap) { theString = stringToWrap; }
    }
    // Custom JsonConverter that will just dump the raw string into
    // the serialization process.  Loosely based on:
    //   http://www.newtonsoft.com/json/help/html/CustomJsonConverter.htm
    public class JsonStringWrapperConverter : JsonConverter
    {
        private readonly Type _type = typeof(JsonStringWrapper);
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                string rawValue = ((JsonStringWrapper)value).theString;
                writer.WriteRawValue((rawValue == null) ? "null" : rawValue);
            }
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return _type == objectType;
        }
    }
    // Custom JsonResult that will use the converter above, largely based on:
    //   http://stackoverflow.com/questions/17244774/proper-json-serialization-in-mvc-4
    public class PreSerializedJsonResult : JsonResult
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new JsonStringWrapperConverter() }
        };
        public override void ExecuteResult(ControllerContext context)
        {
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("GET request not allowed");
            }
            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(this.ContentType) ? this.ContentType : "application/json";
            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }
            if (this.Data == null)
            {
                return;
            }
            response.Write(JsonConvert.SerializeObject(this.Data, Settings));
        }
    }
    // My base controller method that overrides Json()...
    protected JsonResult Json(string message, object data)
    {
        PreSerializedJsonResult output = new PreSerializedJsonResult();
        object finalData = (data is string && (new char[] { '[', '{' }.Contains(((string)data).First())))
            ? new JsonStringWrapper(data as string)
            : data;
        output.Data = new
        {
            success = string.IsNullOrEmpty(message),
            message = message,
            data = finalData
        };
        output.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        output.MaxJsonLength = int.MaxValue;
        return output;
    }
    // Aaaand finally, here's how it might get called from an Action method:
    ...
    return Json("This was a failure", null);
    ...
    return Json(null, yourJsonStringVariableHere);
