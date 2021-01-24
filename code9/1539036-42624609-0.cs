    class Program {
        public static void Main() {
            var proxyGenerator = new ProxyGenerator();
            var container = new Container(config => {
                config.For<ITrafficSourceRepository>(Lifecycles.Transient)
                    .DecorateAllWith(instance => proxyGenerator
                        .CreateInterfaceProxyWithTargetInterface(instance,
                            new LoggingInterceptor()))
                    .Use<TrafficSourceRepository>();
            });
            var ts = container.GetInstance<ITrafficSourceRepository>();
            ts.Call();
            Console.ReadKey();
        }        
    }
    public interface ITrafficSourceRepository {
        void Call();
    }
    public class TrafficSourceRepository : ITrafficSourceRepository {
        public void Call() {
            Console.WriteLine("Called");
            throw new Exception("Ex");
        }
    }
    public class LoggingInterceptor : IInterceptor {
        public void Intercept(IInvocation invocation) {
            try {
                invocation.Proceed();
            }
            catch (Exception ex) {
                Console.WriteLine("Intercepted: " + ex.Message);
            }
        }
    }
