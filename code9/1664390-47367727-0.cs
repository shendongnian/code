    public class Program
    {
        static void Main(string[] args)
        {
            var actionNameFromDb = "Do"; // Get it from db or wherever
            var callback = (Action)GetFunctionName<Program>(actionNameFromDb).CreateDelegate(typeof(Action));
            Action handler = callback;
            callback();
            Console.Read();
        }
        public static void Do()
        {
            Console.Write("Do was called.");
        }
        public static MethodInfo GetFunctionName<T>(string _func)
        {
            Type thisType = typeof(T);
            MethodInfo theMethod = thisType.GetMethod(_func);
            return theMethod;
        }
    }
