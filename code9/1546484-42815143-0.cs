     public object _lock = new object();
     public void ByteTransferResume(int indexResume)
     {
         lock (_lock)
         {
             HttpWebRequest req;
             //rest of your method         
         }
      }
