    using System;
    namespace ConsoleApplication2
    {
        using System.Diagnostics;
        using System.Reflection;
        using ClassLibrary1;
    class Program
    {
        
        static void Main(string[] args)
        {
            var prReflection = new TestReflection<Class1>();
            var elapsed = prReflection.TestFunc(new Class1(), @"C:\Users\yasir\Documents\visual studio 2013\Projects\ConsoleApplication2\ClassLibrary1\bin\Debug\ClassLibrary1.dll", "WriteNoParam", new string[0]);
            Console.WriteLine("Elapsed time for non parameter method: "+elapsed);
            elapsed = prReflection.TestFunc(new Class1(), @"C:\Users\yasir\Documents\visual studio 2013\Projects\ConsoleApplication2\ClassLibrary1\bin\Debug\ClassLibrary1.dll", "WriteWithParam", new[]{"Yasir"});
            Console.WriteLine("Elapsed time for parameter method: " + elapsed);
            Console.ReadLine();
        }
    }
    public class TestReflection<T> where T: class
    {
        public Func<T, string, string, string[], long> TestFunc = (arg1, s, s2, arr) =>
        {
            var assembly = Assembly.LoadFile(s);
            var type = assembly.GetType(typeof (T).ToString());
            long executionTime;
            if (type != null)
            {
                var methodInfo = type.GetMethod(s2);
                if (methodInfo != null)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    object classInstance = Activator.CreateInstance(type, null);
                    var stopWatch = new Stopwatch();
                    if (parameters.Length == 0)
                    {
                        // This works fine
                        stopWatch.Start();
                        methodInfo.Invoke(classInstance, null);
                        return stopWatch.ElapsedMilliseconds;
                    }
                    stopWatch.Start();
                    methodInfo.Invoke(classInstance, arr); ;
                    return stopWatch.ElapsedMilliseconds;
                }
            }
            return 0;
        };
    }
    }
