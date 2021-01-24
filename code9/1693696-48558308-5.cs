    public MyPropertyType MyProperty {get; private set;}
    public event EventHandler MyPropertyChanged;
    protected virtual void OnMyPropertyChanged ()
	{
        // note: needs availability of null coalesence operator:
		this.MyPropertyChanged?.Invoke(this, EventArgs.Empty);
	}
    private SomeOtherFunction()
    {
        this.MyProperty = ...
        this.OnMyPropertyChanged();
    }
