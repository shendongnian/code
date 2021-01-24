    #region ViewModelBase Class
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion INotifyPropertyChanged
    }
    #endregion ViewModelBase Class
    #region VideopPlayerViewModel Class
    public class VideopPlayerViewModel : ViewModelBase
    {
        #region MovieElapsedTime Property
        private TimeSpan _movieElapsedTime = default(TimeSpan);
        public TimeSpan MovieElapsedTime
        {
            get { return _movieElapsedTime; }
            set
            {
                if (value != _movieElapsedTime)
                {
                    _movieElapsedTime = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion MovieElapsedTime Property
    }
    #endregion VideopPlayerViewModel Class
