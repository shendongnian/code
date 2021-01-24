    public class FtdiConnection : IDisposable
    {
       private FtdiDevice device;
       public FtdiConnection(FtdiDevice device)
       {
           this.device = device;
       }
       public void Dispose()
       {
           device.Close();
       }
    }
