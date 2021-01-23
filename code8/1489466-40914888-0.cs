    internal void NotifySubPropertyChange(DependencyProperty dp)
    {
        InvalidateSubProperty(dp);
 
        // if the target is a Freezable, call FireChanged to kick off
        // notifications to the Freezable's parent chain.
        Freezable freezable = this as Freezable;
        if (freezable != null)
        {
            freezable.FireChanged();
        }
    }
