    public class Choice
    {
        [XmlIgnore]
        public string[] Options { get; set; }
        [XmlAttribute]
        public string OptionsSerialized
        {
            get { return ToCsv(Options); }
            set { Options = FromCSV(value); }
        }
        private string ToCsv(string[] input)
        {
           //implementation here
        }
        private string[] FromCsv(string[] input)
        {
           //implementation here
        }
    }
