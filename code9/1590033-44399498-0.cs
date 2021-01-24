    private List<Action> unregisterEvents = new List<Action>();
    private void RegisterEvent(Action registerAction, Action unregisterAction)
    {
        registerAction.Invoke();
        unregisterEvents.Add(unregisterAction);
    }
