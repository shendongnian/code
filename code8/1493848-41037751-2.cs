    public class Broker
    {
         public Broker(IList<IReceiver> receivers)
         {
              Receivers = receivers;
         }
         
         public IList<IReceiver> { get; }
    }
