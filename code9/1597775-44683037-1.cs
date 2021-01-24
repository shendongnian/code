    public class Y
    {
    }
    public class YSubclass : Y
    {
    }
    public class Generic<T> where T : Y, new() {
        public static void Test() {
            //  NEVER DO THIS, EVER
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
        //  And that's why what I did in Test() is a really, really bad idea
        //  and you should never do it. 
        Generic<YSubclass>.Test();
    }
