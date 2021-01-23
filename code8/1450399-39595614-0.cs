    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] String propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
    public class Setting : ViewModelBase
    {
        public string Name { get; set; }
        #region IsEnabled Property
        private bool _isEnabled = false;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion IsEnabled Property
        #region ExecutionTimeId
        private int _executionTimeId = 0;
        public int ExecutionTimeId
        {
            get { return _executionTimeId; }
            set
            {
                if (value != _executionTimeId)
                {
                    _executionTimeId = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion ExecutionTimeId
    }
