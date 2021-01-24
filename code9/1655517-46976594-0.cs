    namespace ConsoleApp3
    {
        using System;
        using System.Reflection;
    
        public static class DataContainer
        {
            public static string MethodName { get; set; }
        }
    
        public class DoInvocations
        {
            public void Method()
            {
                typeof(Execute).InvokeMember(
                    DataContainer.MethodName,
                    BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public,
                    null, null, null);
            }
        }
    
        public class Execute
        {
            public static void DoSomething()
            {
                Console.WriteLine(DataContainer.MethodName);
            }
        }
    
        class Program
        {
            static void Main()
            {
                DataContainer.MethodName = "DoSomething";
    
                new DoInvocations().Method();
    
                Console.ReadLine();
            }
        }
    }
