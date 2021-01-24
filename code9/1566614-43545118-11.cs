    // We need some base interface that we can use for return values
    public interface IResult { }
    // We have to wrap normal return values
    public class Result<T> : IResult
    {
        public Result(T result) { this.Value = result; }
        public T Value { get; private set; }
    }
    // A few classes for messages, errors, warnings, ...
    public class Message : IResult
    {
        public Message(string format, params object[] args)
        {
            this.Text = string.Format(format, args);
        }
        public string Text { get; private set; }
        internal virtual void Handle(List<Message> messages)
        {
            messages.Add(this);
        }
    }
    public class Error : Message
    {
        public Error(Exception ex) :
            base("Uncaught exception: {0}", ex.Message)
        { }
        public Error(string format, params object[] args) : 
            base(format, args)
        { }
        internal override void Handle(List<Message> messages)
        {
            throw new ValidationException(this.Text);
        }
    }
    // Other wrappers like warnings, etc. 
    // Wrapping IEnumerable<IResult> is useful too.
