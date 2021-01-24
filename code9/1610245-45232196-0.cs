    public class CommandRouterActor : UntypedActor
    {
        public Dictionary<Type, IActorRef> RoutingTable { get; }
        private ILoggingAdapter _log = Context.GetLogger(new SerilogLogMessageFormatter());
        public CommandRouterActor(IActorResolver resolver)
        {
            var props = resolver.CreateCommandHandlerProps();
            RoutingTable = props.ToDictionary(k => k.Item1, v => Context.ActorOf(v.Item2, $"CommandHandler-{v.Item1.Name}"));
        }
        protected override void OnReceive(object message)
        {
            _log.Info("Routing command {cmd}", message);
            var typeKey = message.GetType();
            if (!RoutingTable.ContainsKey(typeKey))
            {
                    Sender?.Tell(Response.WithException(
                        new RoutingException(
                            $"Could not route message to routee. No routees found for message type {typeKey.FullName}")));
                    _log.Info("Could not route command {cmd}, no routes found", message);
            }
            RoutingTable[typeKey].Forward(message);
        }
        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(x => Directive.Restart);
        }
    }
