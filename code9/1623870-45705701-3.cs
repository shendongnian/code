    interface IGrandparent
    {
        void DoSomething();
    }
    interface IParent : IGrandparent
    {
        void DoSomethingElse();
        void DoSomething();
    }
    
    public class Child : IParent
    {
        void IGrandparent.DoSomething()
        {
        }
        public void DoSomethingElse()
        {
        }
        public void DoSomething()
        {
        }
    }
