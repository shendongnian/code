    public class EventAction
    {
        public static EventAction Add(int value) => new AddAction(value);
        public static readonly RequestViewAction RequestView = new RequestViewAction();
        public static readonly EventAction Complete = new CompleteAction();
    }
    public class AddAction : EventAction
    {
        public readonly int Value;
        public AddAction(int value) => Value = value;
    }
    public class CompleteAction : EventAction
    {
    }
    public class RequestViewAction : EventAction
    {
    }
