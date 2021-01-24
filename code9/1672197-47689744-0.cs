    class MySuperClass
    {
      private readonly object _syncRoot  = new object();
      private Queue<MyData>   _dataQueue = new Queue<MyData>();
      private AutoResetEvent  _ev        = new AutoResetEvent(false);
      
      public bool ReadData(out List<MyData> dataList)
      {
        dataList = new List<MyData>();
        _autoResetEvent.WaitOne();
        lock(_syncRoot) // lock access to queue for other threads
        {
          while(_dataQueue.Count > 0)
          {
            dataList.Add(_dataQueue.Dequeue());
          }
        }        
        return true;  
      }
    
      /// async socket callback and data parse
      private void MyAsyncCallback(byte rawData)
      {
        MyData data;
        while (canParse(rawData, out data)) 
        { // somehow parse the raw bytes 
          //if we could parse, signal that we have a packet
          lock(_syncRoot) // lock access to queue for other threads
          {
            _dataQueue.Enqueue(data);
          }
        }
        _ev.Set(); // set the signal after all packets parsed, depends on your requirements, maybe after each?
      }
    }
