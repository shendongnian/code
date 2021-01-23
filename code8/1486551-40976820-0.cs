    // in your PCL
    public interface IScanReceiver
    {
    }
    // in your android project
    public class Receiver1 : BroadcastReceiver, IScanReceiver
    
    // in your viewmodel
    MessagingCenter.Subscribe<IScanReceiver>();
