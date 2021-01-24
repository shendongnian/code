    public class DllWrapper : IDisposable
    {
         private static object _lockObject = new object();
         private int _apiHandle;
         private bool _isOpen;
         public void StartSession()
         {
             lock (_lockObject) {
                 _apiHandle = ...; // TODO: open the session
             }
             _isOpen = true;
         }
         public void CloseSession()
         {
             const int MaxTries = 10;
             for (int i = 0; _isOpen && i < MaxTries; i++) {
                 try {
                     lock (_lockObject) {
                         // TODO: close the session
                     }
                     _isOpen = false;
                 } catch {
                 }
             }
         }
         public void Dispose()
         {
             CloseSession();
         }
    }
