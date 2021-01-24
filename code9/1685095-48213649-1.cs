    public class ClassThatDependsOnSomething
    {
        private readonly IDependsOnThis _dependsOnThis;
        public ClassThatDependsOnSomething(IDependsOnThis dependsOnThis)
        {
            _dependsOnThis = dependsOnThis;
        }
    }
