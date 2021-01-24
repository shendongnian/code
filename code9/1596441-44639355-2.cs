    using System.Runtime.CompilerServices;
    ...
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public bool IsChecked
    {
        get { return isChecked; }
        set
        {
            isChecked = value;
            NotifyPropertyChanged();
        }
    }
