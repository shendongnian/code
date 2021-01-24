    [ServiceContract]
    public interface IHackMeService
    {
        [OperationContract]
        [CleanOperationBehavior]
        int Get(string hack, string me, int beach);
    }
