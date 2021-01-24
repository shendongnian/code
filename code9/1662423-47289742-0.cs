    public interface IPayloadDatagram
    {
        Datagram Payload { get; }
    }
    public abstract class Datagram
    {
        public static Datagram CreateFromDatagram(Datagram datagram)
        {
            var action = datagram.GetConverter();
            return action(datagram);
        }
        
        protected abstract Func<Datagram, Datagram> GetConverter();
    }
    public class EthernetDatagram : Datagram, IPayloadDatagram
    {
        protected override Func<Datagram, Datagram> GetConverter()
        {
            return x => new EthernetDatagram();
        }
        public Datagram Payload { get; set; }
    }
    public class TcpDatagram : Datagram, IPayloadDatagram
    {
        protected override Func<Datagram, Datagram> GetConverter()
        {
            return x => new TcpDatagram();
        }
        public Datagram Payload { get; set; }
    }
    public static class DatagramExtensions
    {
        public static T As<T>(this IPayloadDatagram datagram) where T : Datagram
        {
            return (T)Datagram.CreateFromDatagram(datagram.Payload);
        }
    }
