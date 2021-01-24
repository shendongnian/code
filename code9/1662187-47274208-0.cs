    class Program
    {
        static void Main(string[] args)
        {
            var arguments = new object();
            ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod<ObjectA>), args);
            ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod<ObjectB>), args);
            ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod<ObjectC>), args);
            Console.ReadLine();
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
