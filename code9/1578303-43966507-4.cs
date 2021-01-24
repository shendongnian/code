    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool NotifyPropertyChanged<T>(ref T variable, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(variable, value)) return false;
            variable = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }
    }
    class MainViewModel : ViewModelBase
    {
        private Lamp _HallLamp, _StairsLamp;
        private Switch _DownSwitch, _UpSwitch;
        private IRelayCommand _DownSwitchCommand, _UpSwitchCommand;
        public MainViewModel()
        {
            #region entrance
            Grid entranceGrid = new Grid("Entrance Grid");
            _HallLamp = new Lamp("Hall Lamp");
            _StairsLamp = new Lamp("Stairs Lamp");
            _DownSwitch = new Switch("Downstair Switch");
            _UpSwitch = new Switch("Upstair Switch");
            _DownSwitch.Subscribe(entranceGrid);
            _UpSwitch.Subscribe(entranceGrid);
            entranceGrid.Subscribe(_HallLamp);
            entranceGrid.Subscribe(_StairsLamp);
            #endregion // entrance
        }
        private string LampToTxt(Lamp lamp)
        {
            return lamp.Light ? "ON" : "OFF";
        }
        public string TxtHallLamp
        {
            get
            {
                return LampToTxt(_HallLamp);
            }
        }
        public string TxtStairsLamp
        {
            get
            {
                return LampToTxt(_StairsLamp);
            }
        }
        private void NotifyEntranceGridPropertyChanged()
        {
            NotifyPropertyChanged(nameof(TxtHallLamp));
            NotifyPropertyChanged(nameof(TxtStairsLamp));
        }
        public IRelayCommand DownSwitchCommand
        {
            get
            {
                return _DownSwitchCommand ?? (_DownSwitchCommand = new RelayCommand(
                    () => {
                        _DownSwitch.Press();
                        NotifyEntranceGridPropertyChanged();
                    },
                    () => true));
            }
        }
        public IRelayCommand UpSwitchCommand
        {
            get
            {
                return _UpSwitchCommand ?? (_UpSwitchCommand = new RelayCommand(
                    () => {
                        _UpSwitch.Press();
                        NotifyEntranceGridPropertyChanged();
                    },
                    () => true));
            }
        }
    }
