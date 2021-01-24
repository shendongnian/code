    static void Main(string[] args)
            {
    
                IPluginInterface foo = new Foo();
                IPluginInterface fooWithActivator = (IPluginInterface) Activator.CreateInstance(typeof(Foo));
                Console.WriteLine(foo);
                var cloneOfFoo = foo.DeepClone();
                var cloneOfFooWithActivator = fooWithActivator.DeepClone();
    
                Console.WriteLine(cloneOfFoo);
                Console.WriteLine(cloneOfFoo == foo);
                Console.WriteLine(cloneOfFoo.GetType());
    
                Console.WriteLine(cloneOfFooWithActivator);
                Console.WriteLine(cloneOfFooWithActivator == foo);
                Console.WriteLine(cloneOfFooWithActivator.GetType());
    
                Console.ReadLine();
            }
