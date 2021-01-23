    public delegate void LongTimeAfterEventHandler(Func<MyObject>);
    
    public event LongTimeAfterEventHandler LongTimeAfterEventTriggred;
    public MyObject MyExecution(P1 p1, P2 p2, P3 p3, P4 p4)
    {
       //Assuming that object of "MyObject" is needed to pass only in "LongTimeAfter" method
      if(LongTimeAfterEventTriggred != null)
          LongTimeAfterEventTriggred(new Invokable<MyObject>(new MyObject(p1,p2,p3,p4)));
    }
    
    public LongTimeAfter(Func<MyObject> invk)
    {
      MyObject obj = invk.Invoke();
    }
    
    public void Main(P1 p1, P2 p2, P3 p3, P4 p4)
    {
      this.LongTimeAfterEventTriggred += LongTimeAfter;
      MyExecution(P1 p1, P2 p2, P3 p3, P4 p4);
    }
