    public abstract class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            
            protected virtual void NotifyPropertyChanged(params string[] propertyName)
            {
                foreach (var prop in propertyName)
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(prop));
                }
            }
    
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, args);
                }
            }
        }
