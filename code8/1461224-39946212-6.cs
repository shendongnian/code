    public class BindableBase : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged = delegate { };
      protected virtual void OnPropertyChanged(string propertyName)
      {
        PropertyChangedEventHandler handler = this.PropertyChanged;
        if (handler != null)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }
      }
    }
