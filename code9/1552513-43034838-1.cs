    public partial class AClass : ISomeBase
    {
        public AClass() { }
        public int Id { get; set; }
        [JsonProperty(ItemConverterType = typeof(CustomCreationConverter<IGenre, SysType>))]
        public IList<IGenre> Genres { get; set; }
        [JsonProperty("production_countries", ItemConverterType = typeof(CustomCreationConverter<IProductionCountry, ProductionCountry>))]
        public IList<IProductionCountry> ProductionCountries { get; set; }
        [JsonProperty("spoken_languages", ItemConverterType = typeof(CustomCreationConverter<ISpokenLanguage, SpokenLanguage>))]
        public IList<ISpokenLanguage> SpokenLanguages { get; set; }
    }
    public class CustomCreationConverter<T, TSerialized> : CustomCreationConverter<T> where TSerialized : T, new()
    {
        public override T Create(Type objectType)
        {
            return new TSerialized();
        }
    }
