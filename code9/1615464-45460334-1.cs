    private enum MethodCallEnum { None, Method1, Method2 };
    private Queue<MethodCallEnum> _queue = new Queue<MethodCallEnum>();
    private AutoResetEvent _evtQueue = new AutoResetEvent(false);
    private object _syncRoot = new object();
    private Thread _myRCWWorker;
    private void CancellationTokenSource _cancelSource = new CancellationTokenSource();
    // maybe in your main form
    protected override void OnLoad(EventArgs e)
    {  
      base.OnLoad(e);
      // create one and only background thread for RCW access
      _myRCWWorker = new Thread(() => DoRCWWork(_cancelSource.Token, _evtQueue));
      _myRCWWorker.IsBackground = true;
      _myRCWWorker.Start();
    }
    private void CallMethod1()
    {
      Enqueue(MethodCallEnum.Method1);
    }
    private void Enqueue(MethodCallEnum m)
    {
      lock(_syncRoot)
      {
        _queue.Enqueue(m);
      }
      _evtQueue.Set(); // signal new method call
    }
    private MethodCallEnum Dequeue()
    {
      MethodCallEnum m = MethodCallEnum.None;
      lock(_syncRoot)
      {
        if(_queue.Count > 0)
          m = _queue.Dequeue();
      }      
      return m;
    }
    private void DoRCWWork(CancellationToken cancelToken, WaitHandle evtQueue)
    {
      MyRCWType objServer = null;
      int waitResult;
      try
      {
        objServer = new MyRCWType(); // create COM wrapper object
        while (!cancelToken.IsCancellationRequested)
        {
          if(evtQueue.WaitOne(200))
          {
            MethodCallEnum m = Dequeue();
            switch(m)
            {
              case MethodCallEnum.Method1:
                objServer.MyMethodCall1();
              break;
              case MethodCallEnum.Method2:
                objServer.MyMethodCall2();
              break;
            }
          }
        }
      }
      catch(Exception ex)
      {
        // Handle exception
      }
      finally
      {
        if(objServer != null)
        {
          while(Marshal.ReleaseComObject(objDA) > 0); // dispose COM wrapper object
        }
      }
    }
