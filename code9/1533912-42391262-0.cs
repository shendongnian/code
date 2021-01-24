    public interface IValidated
    {
        bool AlreadyValidated { get; }
    }
    public sealed class Command : IRequest, IValidated
    {
        public bool AlreadyValidated { get; set; }
        // etc...
    }
