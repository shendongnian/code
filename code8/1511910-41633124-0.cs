    public MyObject MyExecution(P1 p1, P2 p2, P3 p3, P4 p4)
    {
      return new MyObject(p1,p2,p3,p4);
    ]
    public LongTimeAfter(Func<MyObject> invk)
    {
      MyObject obj = invk();
    }
    public void Main(P1 p1, P2 p2, P3 p3, P4 p4)
    {
      Func<MyObject> invk = () => { return MyExecution(p1, p2, p3, p4);};
      LongTimeAfter(invk);
    }
