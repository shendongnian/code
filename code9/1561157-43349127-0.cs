    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            HandleResponse("foo", typeof(string));
        }
        
        static void HandleResponse(object data, Type type)
        {
            string local = "This was a local variable";
            void UseAs<T>(T obj)
            {
                Console.WriteLine($"Object is now a: {typeof(T)}:");
                // Proof that we're capturing the target too
                Console.WriteLine($"Local was {local}");
            }
            
            InvokeHelper(UseAs, data, type);
        }
        
        // This could be in any class you want
        static void InvokeHelper(Action<int> int32Action, object data, Type type)
        {
            // You probably want to validate that it really is a generic method...
            var method = int32Action.Method;
            var genericMethod = method.GetGenericMethodDefinition();
            var concreteMethod = genericMethod.MakeGenericMethod(new[] { type });
            concreteMethod.Invoke(int32Action.Target, new[] { data });
        }
    }
