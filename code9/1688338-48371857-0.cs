    private bool _isLoading = false;
    public virtual bool IsLoading
    {
        get { return _isLoading; }
        set
        {
            SetProperty(ref _isLoading, value);
            if (value)
                BTProgressHUD.Show();
            else BTProgressHUD.Dismiss();
        }
    }
