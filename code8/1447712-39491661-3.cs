    public class EventSender
    {
        public class EventArgsType : EventArgs
        {
            public EventArgsType(string fileName) : base()
            {
                FileName = fileName;
            }
            public string FileName
            {
                get;
                private set;
            }
        }
        public event EventHandler<EventArgsType> MyEvent;
        protected void OnMyEvent(string filename)
        {
            if (MyEvent != null)
                MyEvent(this, new EventArgsType(filename));
        }
    }
