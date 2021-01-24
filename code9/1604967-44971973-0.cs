    public class MyConverter: JsonConverter
    {
        public override bool CanConvert(Type type)
        {
            var canConvert = type == typeof(DateTime) || type == typeof(DateTime?);
            return canConvert;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new NotSupportedException("An attempt to read a date using a write-only converter from DateTime -> number of milliseconds since 1970.");
        }
        static readonly long ticksTo1970 = new DateTime(1970, 1, 1).Ticks;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                var date = (DateTime)value;
                var unixDateSpan = new TimeSpan(date.Ticks - ticksTo1970);
                var milliseconds = (long)unixDateSpan.TotalMilliseconds;
                writer.WriteValue(milliseconds);
            }
            else
            {
                throw new NotSupportedException("A value of unexpected type where a DateTime value is expected.");
            }
        }
    }
    public class BaseApiController : ApiController
    {
        [NonAction]
        protected JsonResult<T> MyJson<T>(T data)
        {
            var result = this.Json(data);
            result.SerializerSettings.Converters.Insert(0, new MyConverter());
            return result;
        }   
    }
