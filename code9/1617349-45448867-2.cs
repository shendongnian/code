    public class Store
    {
        public string sName { get; set; }         // BØRSTER
        public string sImportFile { get; set; }   // 1 
        public string sID { get; set; }           // 1662
        public Store(string id, string strName, string strImportFile)
        {
            sName = strName;
            sImportFile = strImportFile;
            sID = id;
        }
    }
