    public interface IDoesSomethingWith<T>
    {
        void DoSomethingWith(T theThing);
    }
    public class DoesSomethingWithInt : IDoesSomethingWith<int>
    {
        public void DoSomethingWith(int theThing)
        {
           
        }
    }
