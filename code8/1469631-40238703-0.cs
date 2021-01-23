    public class MyClient2 : MyClient
    {
        void IDisposable.Dispose()
        {
            base.Dispose();
            //Do whatever you like here.
        }
    }
