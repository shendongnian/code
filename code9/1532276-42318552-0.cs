    using System;
    using System.Collections.Generic;
    
    namespace Generics
    {
        // create some dummy interfaces and implementations. 
        // make sure everything inherits from the same type to allow for 
        // a generic return statement
        public interface IFactory
        {
            void DoStuff();
        }
        public interface IFactory1 : IFactory { }
        public class Factory1 : IFactory1
        {
            public void DoStuff()
            {
                Console.WriteLine("Factory1");
            }
        }
        public interface IFactory2 : IFactory { }
        public class Factory2 : IFactory2
        {
            public void DoStuff()
            {
                Console.WriteLine("Factory2");
            }
        }
    
    
        class Program
        {
            // create our binding mappings
            IDictionary<Type, Type> bindings = new Dictionary<Type, Type>()
                {
                    // expose a way for plugins/etc to add to this. that part is trivial.
                    {typeof(IFactory1), typeof(Factory1) },
                    {typeof(IFactory2), typeof(Factory2) }
                };
    
            // a method to actually resolve bindings based on expected types
            public IFactory ResolveBinding<T>() where T : IFactory
            {
                Type requestedType = typeof(T);
                if (requestedType != null && bindings.ContainsKey(requestedType))
                {
                    // use the activator to generically create an instance
                    return (T) Activator.CreateInstance(bindings[requestedType]);
                }
    
                return null;
            }
    
            // test it out
            static void Main(string[] args)
            {
                Program demo = new Program();
                // test with two interfaces
                demo.ResolveBinding<IFactory1>().DoStuff(); // prints out "Factory1"
                demo.ResolveBinding<IFactory2>().DoStuff(); // prints out "Factory2"
                Console.ReadKey();
            }
        }
    }
    
