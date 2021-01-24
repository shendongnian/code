    public partial class AClass : ISomeBase
    {
        public AClass() { }
        [JsonConstructor]
        public AClass([JsonProperty("Genres")] IList<SysType> SysTypes, IList<ProductionCountry> production_countries, [JsonProperty("spoken_languages")] IList<SpokenLanguage> SpokenLanguages)
        {
            this.Genres = SysTypes == null ? null : SysTypes.Cast<IGenre>().ToList();
            this.ProductionCountries = production_countries == null ? null : production_countries.Cast<IProductionCountry>().ToList();
            this.SpokenLanguages = SpokenLanguages == null ? null : SpokenLanguages.Cast<ISpokenLanguage>().ToList();
        }
