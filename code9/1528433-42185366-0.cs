    /// <summary>
    /// The are tasks empty.
    /// </summary>
    private bool _areTasksEmpty;
    
    /// <summary>
    /// Gets or sets the are tasks empty.
    /// </summary>
    public bool AreTasksEmpty
    {
        get
        {
            return this._areTasksEmpty;
        }
        set
        {
            this.Set(ref this._areTasksEmpty, value);
        }
    }
