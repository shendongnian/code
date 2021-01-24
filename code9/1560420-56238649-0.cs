    // Assembly A
    public interface IServiceA
    {
       ...
    }
    public class ServiceAFactory
    {
        private static Func<IServiceA> _provider;
        public static void SetProvider( Func<IServiceA> provider )
        {
            _provider = provider;
        }
        public IServiceA Create()
        {
            return _provider();
        }
    }
