    public class UsageItem : INotifyPropertyChanged
    {
        string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    RaisePropertyChanged("Name");
                    RaisePropertyChanged("DisplayName");
                }
            }
        }
        int _ChargesLeft;
        public int ChargesLeft
        {
            get
            {
                return _ChargesLeft;
            }
            set
            {
                if (_ChargesLeft != value)
                {
                    _ChargesLeft = value;
                    RaisePropertyChanged("ChargesLeft");
                    RaisePropertyChanged("DisplayName");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public UsageItem(string name, int charges)
        {
            this.Name = name;
            this.ChargesLeft = charges;
        }
        public string DisplayName
        {
            get
            {
                if (ChargesLeft > 1)
                {
                    return Name + " " + ChargesLeft + "charges";
                }
                else
                {
                    return Name + " " + ChargesLeft + "charge";
                }
            }
        }
    }
