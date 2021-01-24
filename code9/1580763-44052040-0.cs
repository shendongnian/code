    using SimpleInjector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main (string[] args)
            {
                var container = new Container ();
                container.RegisterCollection<IMyInterface> (new[] { typeof (MyImplementationA), typeof (MyImplementationB) });
                var testController = container.GetInstance<TestController> ();
                testController.TestMethod ();
                Console.ReadKey ();
            }
            public interface IMyInterface
            {
                void DoSomething ();
            }
            public class MyImplementationA : IMyInterface
            {
                public void DoSomething () => Console.WriteLine ("A");
            }
            public class MyImplementationB : IMyInterface
            {
                public void DoSomething () => Console.WriteLine ("B");
            }
            public class TestController
            {
                private readonly IMyInterface[] instances;
             
                public TestController (InstancesFactory<IMyInterface> factory)
                {
                    instances = factory.GetInstances ().ToArray ();
                }
                public void TestMethod ()
                {
                    foreach (var instance in instances)
                    {
                        instance.DoSomething ();
                    }
                }
            }
            public class InstancesFactory<T> where T : class
            {
                private readonly Container container;
                public InstancesFactory (Container container)
                {
                    this.container = container;
                }
                public IEnumerable<T> GetInstances ()
                {
                    return container.GetAllInstances<T> ();
                }
            }
        }
    }
