    public class CsvFile2Map : CsvClassMap<StudentWebAccess>
    {
        public CsvFile2Map()
        {            
            Map(m => m.IPAddress).Name("ErrorIPAddress");
            Map(m => m.Code).Name("ErrorMessage");
        }
    }
