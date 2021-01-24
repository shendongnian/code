    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
