    public delegate void MyEventHandler(string s);
    public event MyEventHandler MyEvent;
----
    MyEventHandler @event = s => { };
    MyEvent += @event;
    Console.WriteLine(MyEvent.GetInvocationList().Length);
    MyEvent += @event;
    Console.WriteLine(MyEvent.GetInvocationList().Length);
    MyEvent -= @event;
    Console.WriteLine(MyEvent.GetInvocationList().Length);
