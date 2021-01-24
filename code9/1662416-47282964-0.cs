    public interface IPayloadDatagram
    {
    	Datagram Payload { get; }
    }
    
    public abstract class Datagram : IPayloadDatagram
    {
    	public Datagram Payload { get; }
    
    	protected Datagram(Datagram datagram)
    	{
    		Payload = datagram;
    	}
    }
    
    public class EthernetDatagram : Datagram
    {
    	public EthernetDatagram(Datagram datagram) : base(datagram)
    	{
    	}
    }
    
    public static class DatagramExtensions
    {
    	public static T As<T>(this IPayloadDatagram datagram) where T : Datagram
    	{
    		return (T)Activator.CreateInstance(typeof(T), datagram.Payload);
    	}
    }
