    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool vButton;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool VButton
        {
            get
            {
                return vButton;
            }
            set
            {
                if (value != vButton)
                {
                    this.vButton = value;
                    NotifyPropertyChanged("VButton");
                }
            }
        }
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
