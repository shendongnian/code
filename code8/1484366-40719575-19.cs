    interface ICallTheService
    {
        ServiceResponseModel CallTheService();
    }
    
    enum ServiceResponseModel
    {
        Success,
        PartialSuccess,
        FailureCondition1,
        FailureCondition2,
        // etc...
    }
