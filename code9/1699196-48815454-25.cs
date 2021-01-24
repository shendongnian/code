    public class AddressInfo
    {
        [CsvColumnAttribute("SITE_ID", "^\\d+$")]
        public Int32 SiteId { get; set; }
        [CsvColumnAttribute("HOUSE", "^\\d+$")]
        public Int32 House { get; set; }
        [CsvColumnAttribute("STREET", "^[a-zA-Z0-9- ]+$")]
        public String Street { get; set; }
        [CsvColumnAttribute("CITY", "^[a-zA-Z0-9- ]+$")]
        public String City { get; set; }
        [CsvColumnAttribute("STATE", "^[a-zA-Z]{2}$")]
        public String State { get; set; }
        [CsvColumnAttribute("ZIP", "^\\d{1,5}$")]
        public Int32 Zip { get; set; }
        [CsvColumnAttribute("APARTMENT", "^\\d*$")]
        public Int32? Apartment { get; set; }
    }
