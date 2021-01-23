    interface ICallTheService
    {
        ServiceResponse CallTheService();
    }
    
    enum ServiceResponse
    {
        Success,
        PartialSuccess,
        FailureCondition1,
        FailureCondition2,
        etc...
    }
