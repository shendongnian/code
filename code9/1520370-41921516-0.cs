    public enum SystemKey
    {
        External,
        Internal
    }
    public interface ISystemKeyProvider
    {
        SystemKey GetSystemKey();
    }
    public class SystemKeyProvider : ISystemKeyProvider
    {
        private const string HeaderKey = "SetInternalVersion";
        private readonly HttpRequest _request;
        public SystemKeyProvider(HttpRequest request)
        {
            _request = request;
        }
        public SystemKey GetSystemKey()
        {
            return (_request.Headers[HeaderKey] != null) ? 
                SystemKey.Internal : 
                SystemKey.External;
        }
    }
