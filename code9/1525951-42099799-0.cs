    interface  IDBProcessor
    {
       void Process()
    }
    class ThrowyClass : IDBProcessor
    {
        public Exception ThrowThis {get; set;}
        public void Process() 
        {
            throw ThrowThis;
        }
    }
    void MyMethod(IDBProcessor processor)
    {
      try
      {
        processor.Process()
      }
      catch (DbException ex)
      {
        //Other processing to catch a linked server issue
      }
      catch (Exception ex) 
      {
        //Even more processing for other exceptions
      }
    }
