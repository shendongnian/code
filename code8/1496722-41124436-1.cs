    public class Config
    {
        public CvsConfig Csv { get; private set; }
    
        public Config()
        {
             Csv = new CsvConfig
             {
                 // load stuff from where ever
             }
        }
    }
