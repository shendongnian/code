    class ServiceWrapper<T>
    {
        public T Instance { get; private set; }
        public ServiceWrapper(T instance) {
            Instance = instance;
        }
        public void Close() {
        }
    }
    public interface IBaseInfoWcfService
    {
    }
    public class BaseInfoWcfServiceImpl : IBaseInfoWcfService
    {
        public BaseInfoWcfServiceImpl() {
        }
    }
    public static partial class ServiceFactory
    {
        private static readonly Lazy<ServiceWrapper<IBaseInfoWcfService>> _baseInfoService =
            new Lazy<ServiceWrapper<IBaseInfoWcfService>>(CreateWrapper<IBaseInfoWcfService>);
        public static IBaseInfoWcfService BaseInfoService => _baseInfoService.Value.Instance;
        private static ServiceWrapper<IBaseInfoWcfService> CreateWrapper<T>() where T : IBaseInfoWcfService {
            return new ServiceWrapper<IBaseInfoWcfService>(new BaseInfoWcfServiceImpl());
        }
    }
    static void Main(string[] args) {
        var baseInfoService = typeof(ServiceFactory).GetField("_baseInfoService", BindingFlags.Static | BindingFlags.NonPublic);
        var instance = baseInfoService.GetValue(null);
        var isValueCreated = (bool)instance.GetType().GetProperty("IsValueCreated").GetValue(instance);
        if (isValueCreated) {
            var value = instance.GetType().GetProperty("Value").GetValue(instance);
            var close = (Action)value.GetType().GetMethod("Close").CreateDelegate(typeof(Action), value);
            close();
        }
    }
