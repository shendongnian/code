    protected virtual void OnStateChanged()
    {
    	var stateChanged = this._stateChanged;
        if (stateChanged == null)
    		return;
        
    	stateChanged();
    }
    
    private Action _stateChanged;
    
    public event Action StateChanged
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        add
        {
            this._stateChanged += value;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        remove
        {
            this._stateChanged -= value;
        }
    }
