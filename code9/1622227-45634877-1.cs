    class MyWrapperClass
    {
      CallbackClass CallbackClass;
     public MyWrapperClass()
     {
        this.CallbackClass = new CallbackClass();
        CallbackClass.DataReturnedEvent =+ ProcessData;
     }
     private void ProcessData(object Data)
     {
       //some data processing
     }
     public DataObject GetData()
     {
        this.CallbackClass.RequestData()               
     }
}
