    public class MyItem : INotifyPropertyChanged
    {
        private string _menge = "";
        public String Menge
        {
            get { return _menge; }
            set
            {
                _menge = value;
                RaisePropertyChanged();
            }
        }
        public string Artikelnr { get; set; } = "";
        public String Bezeichnung { get; set; } = "";
        public String Id { get; set; } = "";
        #region Inotify
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
