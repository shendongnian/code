    [Serializable]
    public class DisplayableException : HttpException
    {
        public string DisplayTitle { get; set; }
        public string DisplayDescription { get; set; }
        public DisplayableException(string title, string description)
            : this(title, description, HttpStatusCode.InternalServerError, null, null)
        {
        }
        public DisplayableException(string title, string description, Exception exception)
            : this(title, description, HttpStatusCode.InternalServerError, null, exception)
        {
        }
        public DisplayableException(string title, string description, string message, Exception exception)
            : this(title, description, HttpStatusCode.InternalServerError, message, exception)
        {
        }
        public DisplayableException(string title, string description, HttpStatusCode statusCode, string message, Exception inner)
            : base((int)statusCode, message, inner)
        {
            DisplayTitle = title;
            DisplayDescription = description;
        }
    }
