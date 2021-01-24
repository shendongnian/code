    [ServiceContract]
    public class Service : IService
    {
       ...
    
        [OperationContract]
        UserRights GetUserRights();
    }
