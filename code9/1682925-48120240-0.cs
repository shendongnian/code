    public class ExampleConverter : CustomCreationConverter<Example>
    {
        public override Example Create(Type objectType)
        {
            return new Example();
        }
        public override object ReadJson(JsonReader reader, Type objectType, 
            object existingValue, JsonSerializer serializer)
        {
            var result = (Example)base.ReadJson(reader, objectType, existingValue, 
                serializer);
            result.favoriteColor = result.oldFavoriteColor;
            return result;
        }
    }
