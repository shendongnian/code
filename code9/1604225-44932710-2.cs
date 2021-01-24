        public interface IEvent
        {
            ushort Id { get; }
        }
        public class Event: IEvent
        {
            public virtual ushort Id { get { return 500; } } // a generic code for generic Event
        }
        public class OnConnect: Event
        {
            public override ushort Id { get { return 505; } } // a more customised error code for generic Event
        }
