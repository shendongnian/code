    public class Datagram
    {
        public byte[] Data { get; set; }
    }        
    
    public interface IPayload
    {
        Datagram Payload { get; }
        IPayload As(IConvertible load);
    }    
    
    public interface IConvertible
    {
        IPayload Convert(IPayload load);
    }
    
    public class EthernetDatagram : IPayload, IConvertible
    {
        public Datagram Payload
        {
            get
            {
                return null;
            }
        }
    
        public IPayload As(IConvertible load)
        {
            return load.Convert(this);
        }
    
        public IPayload Convert(IPayload load)
        {
            return new EthernetDatagram();
        }
    }
    
    public class TcpDatagram : IPayload, IConvertible
    {
        public Datagram Payload
        {
            get
            {
                return null;
            }
        }
    
        public IPayload As(IConvertible load)
        {
            return load.Convert(this);
        }
    
        public IPayload Convert(IPayload load)
        {
            return new TcpDatagram();
        }
    }
        
    
    class Program
    {
        static void Main(string[] args)
        {
            IPayload load = new TcpDatagram();
    
            var result = load.As(new EthernetDatagram()).As(new TcpDatagram());
        }
    }
