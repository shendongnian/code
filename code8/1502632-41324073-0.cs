    public class Manager: IMessenger, IMessageSender
    {
       public event EventHandler<WarningEventArgs> Warning;
  
       // Could also be internal or protected internal
       public void RaiseWarning(object sender, string warning)
       {
          this.Warning?.Invoke(sender, new WarningEventArgs(warning);
       }
    }
    public interface IMessenger{
        event EventHandler<WarningEventArgs> Warning;
    }    
    public interface IMessageSender
    {
        void RaiseWarning(object sender, string warning);
    }
