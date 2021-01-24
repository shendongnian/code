    public class Opdracht : INotifyPropertyChanged
    {
        private bool _yesNo;
        private string _sBehaaldInfo;
        public int OpdrNr { get; set; }
        public string OpdrNaam { get; set; }
        public bool YesNo
        {
            get { return _yesNo; }
            set
            {
                _yesNo = value;
                OnPropertyChanged(nameof(YesNo));
            }
        }
        public string SBehaaldInfo
        {
            get { return _sBehaaldInfo; }
            set
            {
                _sBehaaldInfo = value;
                OnPropertyChanged(nameof(SBehaaldInfo));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
