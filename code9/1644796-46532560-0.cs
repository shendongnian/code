    public delegate void MyHandler<T>(IMyInterface<T> pParam);
    public interface IMyInterface<T>
    {
        event MyHandler<T> EventFired;
    }
    public class ClassA : IMyInterface<int>
    {
        public event MyHandler<int> EventFired;
        private int _Count = 0;
        public void Fire()
        {
            var handler = EventFired;
            if (handler != null) handler(this);
        }
        public override string ToString()
        {
            return "Call: " + (++_Count).ToString();
        }
    }
    public static class Extension
    {
        public static void Add<T>(this IMyInterface<T> i, System.Reflection.MethodInfo method, object method_instance = null)
        {
            if (method.IsGenericMethodDefinition) method = method.MakeGenericMethod(typeof(T));
            Delegate d = Delegate.CreateDelegate(typeof(MyHandler<>).MakeGenericType(typeof(T)), method_instance, method);
            i.GetType().GetEvent("EventFired").GetAddMethod().Invoke(i, new object[] { d });
        }
    }
    public class Program
    {
        public static void Print<T>(IMyInterface<T> val)
        {
            string output = val.ToString();
            Console.WriteLine(output);
            System.Diagnostics.Debug.WriteLine(output);
        }
        static void Main(string[] args)
        {
            ClassA ca = new ClassA();
            ca.EventFired += Print<int>;
            ca.Add(typeof(Program).GetMethod("Print", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public));
            ca.Fire();
        }
    }
