    using System;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            // Compile-time type object to prove I'm not cheating...
            object task = Task.FromResult(1);
    
            var result = task.GetType().GetProperty("Result").GetValue(task);
            
            Func<object> d = () => result;
            Console.WriteLine(d()); // 1
        }
    }
