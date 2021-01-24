    class Program
    {
        static void Main(string[] args)
        {
            var arguments = new object();
            Execute<ObjectA>(args);
            Execute<ObjectB>(args);
            Execute<ObjectC>(args);
            Execute<ObjectA>(args);
            Console.ReadLine();
        }
        static void Execute<T>(object args) where T:BaseObject
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod<T>), args);
        }
        static void MyMethod<T>(object args) where T:BaseObject
        {
            Console.WriteLine(typeof(T).FullName);
        }
    }
    public class BaseObject
    {
    }
    public class ObjectA : BaseObject
    {
    }
    public class ObjectB : BaseObject
    {
    }
    public class ObjectC : BaseObject
    {
    }
