    public class AddressInfo
    {
        [CsvColumnAttribute("SITE_ID")]
        public String SiteId { get; set; }
        [CsvColumnAttribute("HOUSE")]
        public String House { get; set; }
        [CsvColumnAttribute("STREET")]
        public String Street { get; set; }
        [CsvColumnAttribute("CITY")]
        public String City { get; set; }
        [CsvColumnAttribute("STATE")]
        public String State { get; set; }
        [CsvColumnAttribute("ZIP")]
        public String Zip { get; set; }
        [CsvColumnAttribute("APARTMENT")]
        public String Apartment { get; set; }
    }
