    public abstract class Message
    {
        static internal Message CurrentMessageType { get; set; }
        public virtual void ShowNotification(string text) {
            if (CurrentMessageType == null) 
                   CurrentMessageType = new SystemMessage();
        }
    }
