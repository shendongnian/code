    [ServiceContract]
    public interface IService
    {
        [OperationContract(Name = "UserRightsContract")]
        UserRights GetUserRights();
    }
