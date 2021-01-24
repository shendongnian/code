        public interface IEvent
        {
            ushort Id { get; }
        }
        public class Event: IEvent
        {
            public virtual ushort Id {
                get {
                    var name = this.GetType().Name.Replace("Event", "");
                    return name == "" ? "Generic" : name;
                    //will return "Generic" for base
                }
            }
        }
        public class OnConnectEvent: Event
        {
            //no need to override the base class will handle everything, just make sure
            //the name is correct
            //will return "OnConnect"
        }
        public class OnDisconnectEvent: Event
        {
            //no need to override the base class will handle everything, just make sure
            //the names are correct
            //will return "OnDisconnect"
        }
    you can customise even farther by making the event class `abstract`, in case you don't need a generic default event.
