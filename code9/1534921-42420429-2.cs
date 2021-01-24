    public class SomeSubstituteType : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(SomeOriginalType).IsAssignableFrom(objectType);
        }
        // Remainder as before
    }
