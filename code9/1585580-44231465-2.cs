    public class EventDispatcher
    {
        public void Dispatch(IEvent @event)
        {
            Type genericHandlerType = typeof(IEventHandler<>);
            Type handlerType = genericHandlerType.MakeGenericType(@event.GetType());
            foreach (IEventHandler handler in DependencyResolver.Current.GetServices(handlerType))
            {
                handler.Handle(@event);
            }
        }
    }
