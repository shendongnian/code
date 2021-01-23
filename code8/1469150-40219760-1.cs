    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class MyViewModel : ViewModelBase
    {
       
        private int _toolTipStatus = 0;
        private int ToolTipStatus
        {
            get { return _toolTipStatus; }
            protected set {
                if (_toolTipStatus != value)
                {
                    _toolTipStatus = value;
                    OnPropertyChanged(nameof(ToolTipStatus));
                }
            }
        }
    }
    private void Example()
    {            
        ToolTipStatus += 1;
    }
