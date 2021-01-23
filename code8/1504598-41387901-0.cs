    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    
    namespace MyNamespace
    {
        public interface ILogger
        { }
    
        public class TheLogger : ILogger
        { }
    
        class Program
        {
            private static void Main(string[] args)
            {
                IUnityContainer container = new UnityContainer();
                container.LoadConfiguration();
    
                var logger = container.Resolve<ILogger>();
            }
        }
    }
