    public class Y
    {
    }
    public class YSubclass : Y
    {
    }
    public class Generic<T> where T : Y, new() {
        public static void Test() {
            T x = (T)new Y();
        }
    }
...
    public static void Main()
    {
        //  OK
        Generic<Y>.Test();
        //  System.InvalidCastException: 'Unable to cast object of type 
        //  'WpfApp1.Y' to type 'WpfApp1.YSubclass'.'
        Generic<YSubclass>.Test();
    }
