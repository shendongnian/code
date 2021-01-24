    public class DefaultDoer : IDoer
    {
        public void DoSomething(object parameters) 
        {
            StaticClass.DoSomething(object parameters);
        }
    }
    
    public class AugmentedDoer : IDoer
    {
        public void DoSomething(object parameters) 
        {
            StaticClass.DoSomething(object parameters);
            DoSomethingElse();
        }
    }
