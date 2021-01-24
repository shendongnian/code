    internal static object Invoke(AutomationPeer peer, DispatcherOperationCallback work, object arg)
    {
        Dispatcher dispatcher = peer.Dispatcher;
        // Null dispatcher likely means the visual is in bad shape!
        if( dispatcher == null )
        {
            throw new ElementNotAvailableException();
        }
        Exception remoteException = null;
        bool completed = false;
        object retVal = dispatcher.Invoke(            
            DispatcherPriority.Send,
            TimeSpan.FromMinutes(3),
            (DispatcherOperationCallback) delegate(object unused)
            {
                try
                {
                    return work(arg);
                }
                catch(Exception e)
                {
                    remoteException = e;
                    return null;
                }
                catch        //for non-CLS Compliant exceptions
                {
                    remoteException = null;
                    return null;
                }
                finally
                {
                    completed = true;
                }
            },
            null);
            
        if(completed)
        {
            if(remoteException != null)
            {
                throw remoteException;
            }
        }
        else
        {
            bool dispatcherInShutdown = dispatcher.HasShutdownStarted;
            if(dispatcherInShutdown)
            {
                throw new InvalidOperationException(SR.Get(SRID.AutomationDispatcherShutdown));
            }
            else
            {
                throw new TimeoutException(SR.Get(SRID.AutomationTimeout));
            }
        }
        
        return retVal;
    }
