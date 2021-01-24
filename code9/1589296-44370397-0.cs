    public class ImageConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var base64 = (string)reader.Value;
            // convert base64 to byte array, put that into memory stream and feed to image
            return Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var image = (Image) value;
            // save to memory stream in original format
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            byte[] imageBytes = ms.ToArray();
            // write byte array, will be converted to base64 by JSON.NET
            writer.WriteValue(imageBytes);
        }
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Image);
        }
    }
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        [JsonConverter(typeof(ImageConverter))]
        public Image photo { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
