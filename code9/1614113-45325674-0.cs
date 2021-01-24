    private static ReferencesEvents _refEvents;
    private static Events2 _dteEvents;
    public void SubscribeEvents()
    {
     EnvDTE.DTE dte = (EnvDTE.DTE)ServiceProvider.GetService(typeof(EnvDTE.DTE));
     _dteEvents = dte.Events as Events2;
     _refEvents = (ReferencesEvents)_dteEvents.GetObject("CSharpReferencesEvents");
     _refEvents.ReferenceAdded += new _dispReferencesEvents_ReferenceAddedEventHandler(ReferenceAdded);
    }
    private void ReferenceAdded(Reference pReference)
    {
      // do some stuff.
    }
