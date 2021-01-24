    public class ViewModel : INotifyPropertyChanged
    {
        private ICommand _Connect;
        public ICommand Connect
        {
            get
            {
                _Connect = new RelayCommand(
                    param => ConnectChip());
                return _Connect;
            }
        }
        private PackIcon _icon = new PackIcon { Kind = PackIconKind.LanDisconnect };
        public PackIcon Icon
        {
            get { return _icon; }
            set { _icon = value; NotifyPropertyChanged(); }
        }
        private void ConnectChip()
        {
            //change icon:
            Icon = new PackIcon { Kind = PackIconKind.Airballoon };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
