    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class AddInUtilities : IAddInUtilities
    {
        ICsvImporter CsvImporter = null;
    
        public void ImportData()
        {
            var activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet as Excel.Worksheet;
            if (activeWorksheet == null) return;
    
            
            if (CsvImporter != null && CsvImporter.IsNotCancelled) loadCsv.AndImportIndexDataInto(activeWorksheet);
        }
    }
    
    public class SiteSpecificClass
    {
        public void SiteImportMethod()
        {
            var addinUtility = new AddInUtilities();
            addinUtility.CsvImporter = new CsvImporter();
            addinUtility.ImportData();
        }
    }
