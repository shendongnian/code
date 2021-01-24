        [ServiceContract(SessionMode = SessionMode.NotAllowed)]
        public interface IMachineData
        {
            [OperationContract(Action="*", ReplyAction="*")]    
            Message GetData();
        }
