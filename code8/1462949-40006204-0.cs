    public delegate void MyEventHandler(string s);
    public event MyEventHandler MyEvent;
----
    MyEventHandler @event = s => { };
    MyEvent += new MyEventHandler(@event);
    Console.WriteLine(MyEvent.GetInvocationList().Length);
    MyEvent += new MyEventHandler(@event);
    Console.WriteLine(MyEvent.GetInvocationList().Length);
    MyEvent -= new MyEventHandler(@event);
    Console.WriteLine(MyEvent.GetInvocationList().Length);
