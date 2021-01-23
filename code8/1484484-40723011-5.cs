    public class NamespaceManagerWrapper : INamespaceManagerWrapper 
    {
       private NamespaceManager _instance;
    
       public NamespaceManagerWrapper(NamespaceManager instance)
       {
          _instance = instance;
       }
    
       public ConsumerGroupDescription CreateConsumerGroup(ConsumerGroupDescription description)
       {
           return _instace.CreateConsumerGroup(description);
       }
    
       etc....
    }
