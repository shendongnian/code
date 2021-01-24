    private EventHandler meEvent;
    public event EventHandler MeEvent
    {
        add { meEvent += value; MeEventInvocationListChanged(); }
        remove { meEvent -= value; MeEventInvocationListChanged(); }
    }
