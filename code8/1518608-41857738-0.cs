    delegate void MyEvent();
    class MyEventSource
    {
        public event MyEvent Event;
        public void RaiseEvent()
        {
            MyEvent evt = Event;
            if (evt != null)
                evt();
        }
    }
    class MyEventListener
    {
        public void SubscribeForEventFromMyEventSource(MyEventSource eventSource)
        {
            eventSource.Event += this.EventHandler;
        }
        public void EventHandler()
        {
            //  Event handling logic here
        }
    }
