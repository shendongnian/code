    public sealed class CsvMap : CsvHelper.Configuration.CsvClassMap<MyModel>
    {
        public CsvMap()
        {
            Map(m => m.Date).TypeConverterOption("MM/dd/yyyy HH:mm:ss.fff");
            Map(m => m.ID);
        }
    }
