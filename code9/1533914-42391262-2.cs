    public interface IValidated
    {
        bool AlreadyValidated { get; }
    }
    public class Command : IRequest, IValidated
    {
        public bool AlreadyValidated { get; set; }
        // etc...
    }
