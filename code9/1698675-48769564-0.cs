    public class CsvRow
    {
        public string vorname { get; set; }
        public string nachname { get; set; }
        public string username { get; set; }
        public CsvRow (string[] data)
        {
             vorname = data[0];
             nachname = data[1];
             username = data[2];
        }
    }
