    [Serializable]
    public class CfgPartPrograms : System.ComponentModel.INotifyPropertyChanged
    {
        public CfgPartPrograms() { }
        public string Group { get; set; }
        public string Description { get; set; }
        private string _fileName;
        public string Filename
        {
            get { return _fileName; }
            set { _fileName = value; NotifyPropertyChanged(); }
        }
        public string Notes { get; set; }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
