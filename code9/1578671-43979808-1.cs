    public class ExcelExporter : IExcelExporter
    {
        private readonly IComAssistant _comAssistant;
        public ExcelExporter(IComAssistant comAssistant)
        {
            _comAssistant = comAssistant;
        }
        private void Export(...)
        {
            //NEED NEW INSTANCE OF EXCEL_APP PER THREAD
            using (IExcelApp excel = new ExcelApp(_comAssistant))
            {
                //Do stuff with excel.
                excel.CreateWorkBook();
                //...
            }
        }
    }
