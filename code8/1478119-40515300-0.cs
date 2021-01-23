    namespace MyNamespace
    {
    
        public static class Worker
        {
            public static void Wait(int msec)
            {
                ....
            }
        }
    }
    
    //In another file
    
    using static MyNamespace.Worker;
    
    public class Foo
    {
        public void Bar()
        {
            Wait(500); //Is the same as calling "MyNamespace.Worker.Wait(500);" here
        }
    }
