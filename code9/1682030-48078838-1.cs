    class ViewModel : INotifyPropertyChanged
    {
        private bool r1 = false;
        private bool r2 = false;
        private bool r3 = false;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool R1
        {
            get { return r1; }
            set { r1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SubmitEnabled")); }
        }
        public bool R2
        {
            get { return r2; }
            set { r2 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SubmitEnabled")); }
        }
        public bool R3
        {
            get { return r3; }
            set { r3 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SubmitEnabled")); }
        }
        public bool SubmitEnabled
        {
            get
            {
                return R1 || R2 || R3;
            }
        }
    }
