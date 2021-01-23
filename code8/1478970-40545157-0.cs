    public event PropertyChangingEventHandler PropertyChanging;
    public void RaisePropertyChanging([CallerMemberName] string propertyName = null)
    {
        PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }
