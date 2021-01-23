    public class Receiver
    {
        private EventSender _sender;
        public Receiver()
        {
            _sender = new EventSender();
            _sender.MyEvent += HandleMyEvent;
        }
        private void HandleMyEvent(object sender, EventSender.EventArgsType e)
        {
            // Do something with e.FileName
        }
    }
