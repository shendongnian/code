    private bool _updatedUser;
    public bool UpdatedUser
    {
        get { return _updatedUser; }
        set { this.SetProperty(ref this._updatedUser, value); }
    }
    private string _column5;
    public string Column5
    {
        get { return _column5; }
        set
        {
            this.SetProperty(ref this._column5, value);
            UpdatedUserCheck();
        }
    }
    private void UpdatedUserCheck()
    {
        this.UpdatedUser = // DO YOUR CHECK HERE
    }
