    private DTE2 _dte2;
    private Events2 _dteEvents;
    private SelectionEvents _selectionEvents;
    
    private void OnLoaded()
    {
        _dte2 = ServiceProvider.GlobalProvider.GetService(typeof(EnvDTE.DTE)) as DTE2;
        _dteEvents = _dte2.Events as Events2;
        _selectionEvents = _dteEvents.SelectionEvents;
        _selectionEvents.OnChange += SelectionEventsOnOnChange;
    }
