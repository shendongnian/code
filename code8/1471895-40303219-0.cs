    class A
    {
      public event EventHappend; // Invalid C# but let's pretend it could work
      public void DoSomething()
      {
        ...
        if (EventHappend != null)
        {
          // What should ??? be replaced with?
          EventHappend(???);
        }
      }
    }
    
    class B
    {
      public B()
      {
        new A().EventHappend += EventHandler;
      }
      public void EventHandler(int anInt)
      ...
    }
    class C
    {
      public C()
      {
        new A().EventHappend += EventHandler;
      }
      public void EventHandler(string aString)
      ...
    }
