    using Unity;
    namespace ConsoleApplication1
    {
        public class Foo
        {
        }
        class Program
        {
            static void Main(string[] args)
            {
                IUnityContainer container = new UnityContainer();
                var f = container.Resolve<Foo>();
            }
        }
    }
