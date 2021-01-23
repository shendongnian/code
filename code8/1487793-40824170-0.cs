    public class ServiceCaller<T>
    {
        public static string CelsiusToFahrenheit(string val)
        {   
            ServiceManager<T> channel = new ServiceManager<T>();
            return channel.InnerChannel.CelsiusToFahrenheit(val);
        }
    }
