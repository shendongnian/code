    class VehicleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vehicle);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Vehicle veh = new Vehicle();
            serializer.Populate(obj.CreateReader(), veh);
            Position pos = new Position();
            serializer.Populate(obj.CreateReader(), pos);
            veh.Position = pos;
            return veh;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Vehicle veh = (Vehicle)value;
            JObject obj = JObject.FromObject(veh.Position, serializer);
            obj.AddFirst(new JProperty("pre", veh.Prefix));
            obj.WriteTo(writer);
        }
    }
