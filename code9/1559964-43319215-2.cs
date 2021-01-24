    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        SaveDataSetResponse SaveDataSet(SaveDataSetRequest request);
    }
