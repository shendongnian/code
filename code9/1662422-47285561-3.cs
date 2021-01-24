    public class Datagram
    {
        public byte[] Data { get; set; }
    }
        
    
    public interface IPayload
    {
        Datagram Payload { get; }
            
    }    
    
    public interface IConvertible
    {
        IPayload Convert(IPayload load);
    }
    
    public class EthernetDatagram : IPayload , IConvertible
    {
        public Datagram Payload
        {
            get
            {
                return null;
            }
        }
            
    
        public IPayload Convert(IPayload load)
        {
            return new EthernetDatagram();
        }
    }
    
    public class TcpDatagram : IConvertible, IPayload
    {
        public Datagram Payload
        {
            get
            {
                return null;
            }
        }
    
        public IPayload Convert(IPayload load)
        {
            return null;
        }
    }
        
    public static  class Extension
    {
        public static IPayload As<T>(this IPayload load) where T : class, IConvertible, new()
        {
            IConvertible conv = new T();
            return conv.Convert(load);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            IPayload load = new TcpDatagram();
    
            var result = load.As<EthernetDatagram>();
        }
    }
   
