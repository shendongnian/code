    public class WidgetConverter : CustomPropertyConverterBase<Widget>
    {
        readonly IDictionary<long, UnitReference> units;
        public WidgetConverter(IDictionary<long, UnitReference> units)
        {
            this.units = units;
        }
        protected override void ReadCustomProperties(JObject obj, Widget value, JsonSerializer serializer)
        {
            var id = (long?)obj.GetValue("UnitReferenceId", StringComparison.OrdinalIgnoreCase);
            if (id != null)
                value.UnitReference = units[id.Value];
        }
        protected override bool ShouldSerialize(JsonProperty property, object value)
        {
            if (property.UnderlyingName == nameof(Widget.UnitReference))
                return false;
            return base.ShouldSerialize(property, value);
        }
        protected override void WriteCustomProperties(JsonWriter writer, Widget value, JsonSerializer serializer)
        {
            if (value.UnitReference != null)
            {
                writer.WritePropertyName("UnitReferenceId");
                writer.WriteValue(value.UnitReference.UnitReferenceId);
            }
        }
    }
    public abstract class CustomPropertyConverterBase<T> : JsonConverter where T : class
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jObj = JObject.Load(reader);
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(objectType);
            var value = existingValue as T ?? (T)contract.DefaultCreator();
            ReadCustomProperties(jObj, value, serializer);
            // Populate the remaining properties.
            using (var subReader = jObj.CreateReader())
            {
                serializer.Populate(subReader, value);
            }
            return value;
        }
        protected abstract void ReadCustomProperties(JObject obj, T value, JsonSerializer serializer);
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());
            writer.WriteStartObject();
            foreach (var property in contract.Properties.Where(p => ShouldSerialize(p, value)))
            {
                var propertyValue = property.ValueProvider.GetValue(value);
                if (propertyValue == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                    continue;
                writer.WritePropertyName(property.PropertyName);
                serializer.Serialize(writer, propertyValue);
            }
            WriteCustomProperties(writer, (T)value, serializer);
            writer.WriteEndObject();
        }
        protected virtual bool ShouldSerialize(JsonProperty property, object value)
        {
            return property.Readable && !property.Ignored && (property.ShouldSerialize == null || property.ShouldSerialize(value));
        }
        protected abstract void WriteCustomProperties(JsonWriter writer, T value, JsonSerializer serializer);
    }
