    public class EventSender
    {
        public event EventHandler<EventArgsType> MyEvent;
        protected void OnMyEvent(...)
        {
            if (MyEvent != null)
                MyEvent(this, new EventArgsType(...));
        }
    }
