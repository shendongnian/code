    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test().Wait();
                Console.ReadLine();
            }
    
            static async Task Test()
            {
                var foo = new Foo();
                var bar2 = new Bar2();
                
                object resultObject = await CallGetByReflection(foo, bar2);
    
                IBar result = (IBar)resultObject;
                result.WriteOut();
    
                //or
    
                if (resultObject is Bar)
                {
                    ((Bar)resultObject).Something();
                }
                else if (resultObject is Bar2)
                {
                    ((Bar2)resultObject).SomethingElse();
                }
            }
    
            private static async Task<object> CallGetByReflection(IFoo foo, IBar bar)
            {
                var method = typeof(IFoo).GetMethod(nameof(IFoo.Get));
                var generic = method.MakeGenericMethod(bar.GetType());
                var task = (Task) generic.Invoke(foo, new[] {bar});
    
                await task.ConfigureAwait(false);
    
                var resultProperty = task.GetType().GetProperty("Result");
                return resultProperty.GetValue(task);
            }
    
            public interface IBar
            {
                void WriteOut();
            }
            public class Bar : IBar
            {
                public void Something()
                {
                    Console.WriteLine("Something");
                }
                public void WriteOut()
                {
                    Console.WriteLine(nameof(Bar));
                }
            }
            public class Bar2 : IBar
            {
                public void SomethingElse()
                {
                    Console.WriteLine("SomethingElse");
                }
                public void WriteOut()
                {
                    Console.WriteLine(nameof(Bar2));
                }
            }
            public interface IFoo
            {
                Task<T> Get<T>(T o) where T : IBar;
            }
            public class Foo : IFoo
            {
                public async Task<T> Get<T>(T o) where T : IBar
                {
                    await Task.Delay(100);
                    return o;
                }
            }
        }
    }
