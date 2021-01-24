    public interface ICaller{
        int DoStuff(dynamic parameters);
    }
    internal class ServiceForA : ICaller
    {
        internal int DoStuff(dynamic parameters)
        {
           //implementation       
        }
    }
    internal class ServiceForB : ICaller
    {
        internal int DoStuff(dynamic parameters)
        {
           //implementation
        }
    }
    public class ServiceProcessor 
    {
        private ICaller _service;
        public ServiceProcessor(ICaller service)
        {
            _service = service;
        }
        public int Invoke(ICaller service)
        {
            return _service.DoStuff(dynamic parameters);
        }
    }
    static void Main()
    {
        var processor = new ServiceProcessor(new ServiceForA());
        processor.Invoke();
        var processor = new ServiceProcessor(new ServiceForB());
        processor.Invoke();
    }
