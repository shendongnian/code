    public class SubSystemAdapter : ISystem
    {
        private SubSystemA _subSystemA;
        private SubSystemB _subSystemB;
        public SubSystemAdapter(SubSystemA subsystemA, SubSystemB subsystemB)
        {
            _subSystemA = subsystemA;
            _subSystemB = subsystemB;
        }
        
        public void ExecuteOperation1()
        {
            _subSystemA.ExecuteA();
            _subSystemB._ExecuteB();
        }
    }
