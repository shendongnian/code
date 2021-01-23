    private bool isChecked;
    public bool IsChecked
    {
        get{ return isChecked;}
        set
        {
            SetIsChecked( value);
            foreach(var child in Children)Parent.SetIsChecked(isChecked)
        }
    }
    public void SetIsChecked(bool value)
    {
        isChecked = value;
        RaisePropertyChanged("IsChecked");
    }
