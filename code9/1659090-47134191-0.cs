    public class ResponseReceivedEventArgs : EventArgs
    {
        public enum EventType
        {
            TextToSpeak,
            OfferingText,
            OfferingImageNo,
            AnimationName,
            Emotion
        }
        public ResponseReceivedEventArgs(EventType eventType, String eventValue)
        {
            Type = eventType;
            Value = eventValue
        }
        public EventType Type {get;}
        public String Value {get;}
    }
