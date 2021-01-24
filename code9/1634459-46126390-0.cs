    public class Tracker
    {
        public static List<Type> Types = new List<Type>();
    }
    public class MyThing<T>
    {
        static MyThing()
        {
            // This is the static constructor, and is called once for every type
            Tracker.Types.Add(typeof(MyThing<T>));
        }
    }
