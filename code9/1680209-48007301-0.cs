    protected Task RunIsolated(Action action) {
        return Task.FromResult(RunInScope(action));
    }
    protected Task RunIsolated(Func<Task> action) {
        return (Task)RunInScope(action);
    }
    private object RunInScope(Delegate d) {
        // do some stuff
        return d.DynamicInvoke();            
    }
