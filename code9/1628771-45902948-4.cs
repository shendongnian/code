    public class writeClass <T> where T : EventData<BaseEventTemplate>  {
        public writeClass(T t)
        {
            data = t;
        }
        // ..... other members 
        public EventData<BaseEventTemplate> data { get; set; }
    
    }
