    public class CoordinateConverter : CustomCreationConverter<Coordinate>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var values = reader.Value.ToString().Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            Coordinate coordinates = new Coordinate() { X = values[0], Y = values[1] };
            return coordinates;
        }
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(Coordinate))
            {
                return true;
            }
            return false;
        }
        public override Coordinate Create(Type objectType)
        {
            return new Coordinate();
        }
    }
