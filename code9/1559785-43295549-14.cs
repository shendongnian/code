    public class ExcelDataServiceClient : ClientBase<IExcelDataService>
    {
        public bool SaveData(List<ExcelData> excelData)
        {
            base.Channel.SaveData(excelData);
        }
    }
