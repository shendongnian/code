    public class StringEnumConverter: JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(MyEnum);
        }
    }
