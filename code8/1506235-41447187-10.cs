    public class LoggerModel
    {
        // ...
        private string event;
    
        public string Event
        { 
            get { return event; }
            set { event = FirstCharToUpper(value); }
        }
        // ...
    }
