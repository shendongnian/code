    class CallbackClass : SomeSdkCallbacks
    {
       public event Action<object> DataReturnedEvent;
        public void RequestData()
       {
        // We call this to request some data.
        // After some time, this will trigger OnDataReturned to be called
       }
      public void OnDataReturned(DataObject data)
      {
        DataReturnedEvent?.Invoke(data);
      }
    }
