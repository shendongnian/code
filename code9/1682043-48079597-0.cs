    internal interface IDoable
    {
        void DoSomething();
    }
    internal interface Informable
    {
        void SomethingHappened(IDoable obj);
    }
    public class MyClass : IDoable, Informable
    {
        void IDoable.DoSomething()
        {
            throw new NotImplementedException();
        }
        void Informable.SomethingHappened(IDoable obj)
        {
            throw new NotImplementedException();
        }
    }
