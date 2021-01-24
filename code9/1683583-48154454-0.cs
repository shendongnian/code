    public interface IDoesSomethingWith<T>
    {
        void DoSomethingWith(T theThing);
    }
    public class DoesSomethingWith<T> : IDoesSomethingWith<T>
    {
        public void DoSomethingWith(T theThing)
        {
            throw new NotImplementedException();
        }
    }
