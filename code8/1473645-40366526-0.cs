    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AreaId { get; set; }
        public Area Area { get; set; }
    }
    
    public class Area
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; } // E.g. the name in a default language
        public ICollection<AreaTranslation> AreaTranslations { get; set; }
    }
    
    public class AreaTranslation
    {
        public int AreaId { get; set; }
        public int LanguageId { get; set; }
        public string LocalizedName { get; set; }
    }
    
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
