    public class NavigationPayload
    {
        public NavigationPayload(string title, object payload)
        {
            Title = title;
            Payload = payload;
        }
        public string Title { get; set; }
        public object Payload { get; set; }
    }
