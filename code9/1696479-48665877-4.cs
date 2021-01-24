    interface IInterfaceToBeMocked
    {
        void Run(int param);        
    }
    public class Sut
    {
        public string CurrentState {get;set;}
        private readonly IInterfaceToBeMocked _dependency;
        public Sut(IInterfaceToBeMocked dependency)
        {
            _dependency = dependency;
        }
        
        public void MethodToBeTested()
        {
            CurrentState = "aaa";
            _dependency.Run(1);
            CurrentState = "bbb";
        }
    }
