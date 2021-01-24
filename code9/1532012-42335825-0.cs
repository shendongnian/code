    dispatch.InstanceContextProvider = InstanceContextProviderBase.GetProviderForMode(this.instanceMode, dispatch);
     
    if ((this.instanceMode == InstanceContextMode.Single) &&
        (dispatch.SingletonInstanceContext == null))
    {
        if (singleton == null)
        {
            if (this.wellKnownSingleton != null)
            {
                singleton = new InstanceContext(serviceHostBase, this.wellKnownSingleton, true, false);
            }
            else if (this.hiddenSingleton != null)
            {
                singleton = new InstanceContext(serviceHostBase, this.hiddenSingleton, false, false);
            }
            else
            {
                singleton = new InstanceContext(serviceHostBase, false);
            }
     
            singleton.AutoClose = false;
        }
        dispatch.SingletonInstanceContext = singleton;
    }
