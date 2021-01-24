    [ServiceContract(..., SessionMode=SessionMode.Required)]
    public interface IService
    {
        [OperationContract(IsTerminating = true)]
        void Close();
    ...
    }
