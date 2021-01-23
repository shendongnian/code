    private object Activate(IEnumerable<Parameter> parameters)
    {
        ComponentRegistration.RaisePreparing(this, ref parameters);
        try
        {
            _newInstance = ComponentRegistration.Activator.ActivateInstance(this, parameters);
        }
        catch (Exception ex)
        {
            throw new DependencyResolutionException(ex);
        }
        if (ComponentRegistration.Ownership == InstanceOwnership.OwnedByLifetimeScope)
        {
            // The fact this adds instances for disposal agnostic of the activator is
            // important. The ProvidedInstanceActivator will NOT dispose of the provided
            // instance once the instance has been activated - assuming that it will be
            // done during the lifetime scope's Disposer executing.
            var instanceAsDisposable = _newInstance as IDisposable;
            if (instanceAsDisposable != null)
                _activationScope.Disposer.AddInstanceForDisposal(instanceAsDisposable);
        }
        ComponentRegistration.RaiseActivating(this, parameters, ref _newInstance);
        return _newInstance;
    }
