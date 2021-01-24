    delegate void MyDelegate(string s);
    event MyDelegate TestEvent;
    private void TestCloning()
    {
      TestEvent += Testing;
      TestEvent += Testing2;
      var eventClone = (MyDelegate)Delegate.Combine(TestEvent.GetInvocationList());
      TestEvent("original");
      eventClone("clone");
      Debug.WriteLine("Removing handler from original...");
      TestEvent -= Testing2;
      TestEvent("original");
      eventClone("clone");
    }
    private void Testing2(string s)
    {
      Debug.WriteLine("Testing2 was called with {0}", s);
    }
    void Testing(string s)
    {
      Debug.WriteLine("Testing was called with {0}", s);
    }
