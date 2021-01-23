    public class Broker<Payload>
    {
         public Broker(IList<IReceiver<PayLoad>> receivers)
         {
              Receivers = receivers;
         }
         
         public IList<IReceiver<PayLoad>> { get; }
    }
