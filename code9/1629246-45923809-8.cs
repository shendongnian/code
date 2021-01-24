    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if(propertyName == nameof(IsEnabled))
        {
             //update controls here
             ...
        }
    }
