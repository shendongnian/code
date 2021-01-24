    public class DoesSomethingWith<T> : IDoesSomethingWith<T>
    {
        public void DoSomethingWith(T theThing)
        {
            // uses generic type of class
        }
        public void DoSomethingWith<TAnotherThing>(TAnotherThing anotherThing)
        {
            // uses generic type of method
        }
        public void DoSomethingWith<TAnotherThing>(T thing, TAnotherThing anotherThing)
        {
            // uses generic type of class and method
        }
    }
