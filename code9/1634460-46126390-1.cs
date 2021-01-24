    public class Tracker
    {
        public static int NumberOfCallsToFoo;
    }
    public class MyThing<T>
    {
        public void Foo(T item) {
            Tracker.NumberOfCallsToFoo++;
            ...
        }
    }
