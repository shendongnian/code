    public T UpdateProperty<T>(T oldValue, T newValue) where T : IObjectState
    {
        if (oldValue != newValue && ObjectState != ObjectState.New && ObjectState != ObjectState.Deleted)
        {
            ObjectState = ObjectState.Changed;
        }
        return newValue;
    }
    public interface IObjectState
    {
        ObjectState ObjectState { get; }
    }
    
    public TicketType : IObjectState { }
