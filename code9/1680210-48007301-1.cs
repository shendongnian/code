    protected Task RunIsolated(Action action) {
        return RunInScope(action);
    }
    protected Task RunIsolated(Func<Task> action) {
        return RunInScope(action);
    }
    protected Task<TResult> RunIsolatedForResult<TResult>(Func<Task<TResult>> action) {
        return RunInScopeWithResult<TResult>(action);
    }
    protected Task<TResult> RunIsolatedForResult<TResult>(Func<TResult> action) {
        return RunInScopeWithResult<TResult>(action);
    }
    private async Task RunInScope(Delegate d, params object[] args) {
        // do some stuff
        using (var scope = _serviceProvider.CreateScope()) {
            object[] parameters = args.Cast<Type>().Select(t => scope.ServiceProvider.GetService(t)).ToArray();
            var result = d.DynamicInvoke(parameters);
            var resultTask = result as Task;
            if (resultTask != null) {
                await resultTask;
            }
        }
    }
    private async Task<TResult> RunInScopeWithResult<TResult>(Delegate d, params object[] args) {
        // do some stuff
        using (var scope = _serviceProvider.CreateScope()) {
            object[] parameters = args.Cast<Type>().Select(t => scope.ServiceProvider.GetService(t)).ToArray();
            var result = d.DynamicInvoke(parameters);
            var resultTask = result as Task<TResult>;
            if (resultTask != null) {
                return await resultTask;
            }
            return (TResult) result;
        }
    }
