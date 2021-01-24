    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var points = (List<Point>)value;
        if (points.Any())
        {
            var converter = new PointConverter();
            writer.WriteStartArray();
            foreach (var point in points)
            {
                converter.WriteJson(writer, point.Coordinates, serializer);
            }
            writer.WriteEndArray();
        }
    }
