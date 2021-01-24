    public interface IAction
        {
        [OperationContract(IsOneWay = true)]
            void OnIndexChanged(int index);
        }
