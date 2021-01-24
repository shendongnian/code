    [ServiceContract]
    public interface IExcelDataService
    {
        [OperationContract]
        bool SaveData(List<ExceData> data);
    }
