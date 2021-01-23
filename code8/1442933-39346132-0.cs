    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
