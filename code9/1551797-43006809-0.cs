     class HcmTerminal {
          public event Action<bool> OnDataReceived;
          public void Launch()
          {
               OnDataReceived?.Invoke(true /*or false*/);
          }
     }
