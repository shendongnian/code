    using System;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                object thing = Activator.CreateInstance<PublicCtorClass>();
            }
        }
    
        class PublicCtorClass : ProtectedCtorGenericClass<PublicParameterisedCtorClass>
        {
            public PublicCtorClass() { }
        }
    
        class ProtectedCtorGenericClass<T>
        {
            protected ProtectedCtorGenericClass()
            {
                object thing = Activator.CreateInstance(typeof(T));
            }
        }
    
        class PublicParameterisedCtorClass
        {
            public PublicParameterisedCtorClass(object arg) { }
        }
    }
