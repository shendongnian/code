    class DataModelConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DataModel);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jobj = JObject.Load(reader);
            if (jobj["$ref"] != null)
            {
                string path = jobj["$ref"].Value<string>();
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<DataModel>(json);
            }
            var model = new DataModel
            {
                id = jobj.Value<string>("id")
            };
            return model;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var model = value as DataModel;
            string path = "data.json";
            string json = $"{{\r\n\t\"$id\" : \"{model.id}\",\r\n\t\"id\" : \"{model.id}\"\r\n}}";
            File.WriteAllText(path, json);
            writer.WriteStartObject();
            writer.WritePropertyName("$ref");
            serializer.Serialize(writer, path);
            writer.WriteEndObject();
        }
    }
