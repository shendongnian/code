    public class ErrorViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        
        // This is only relevant to my business needs
        public string ContentResourceKey { get; set; }
        // I am including the actual exception in here so that in the view,
        // when the request is local, I am displaying the exception for
        // debugging purposes.
        public Exception Exception { get; set; }
    }
