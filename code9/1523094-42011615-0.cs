    public class GlobalReceiver : ServerEventReceiver
    {
        public void Any(FrontendMessage request)
        {
            ...
        }
    }
    
    client.RegisterReceiver<GlobalReceiver>();
