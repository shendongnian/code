    public class CountryData
    {
        public List<Country> Countries { get; set; }
        public CountryData() { Countries = new List<Country>(); }
    }
    public class Country
    {
        [XmlElement]
        public string CountryName { get; set; }
        [XmlElement]
        public string Countrycode { get; set; }
        [XmlElement]
        public string PercentOfBusiness { get; set; }
        [XmlElement]
        public string AverageBusiness { get; set; }
        [XmlElement]
        public string SalesMade { get; set; }
    }
