    public class JObjectNamingStrategyConverter : JsonConverter<JObject> {
    private NamingStrategy NamingStrategy { get; }
    public JObjectNamingStrategyConverter (NamingStrategy strategy) {
        if (strategy == null) {
            throw new ArgumentNullException (nameof (strategy));
        }
        NamingStrategy = strategy;
    }
    public override void WriteJson (JsonWriter writer, JObject value, JsonSerializer serializer) {
        writer.WriteStartObject ();
        foreach (JProperty property in value.Properties ()) {
            var name = NamingStrategy.GetPropertyName (property.Name, false);
            writer.WritePropertyName (name);
            serializer.Serialize (writer, property.Value);
        }
        writer.WriteEndObject ();
    }
    public override JObject ReadJson (JsonReader reader, Type objectType, JObject existingValue, bool hasExistingValue, JsonSerializer serializer) {
        throw new NotImplementedException ();
    }
    }
