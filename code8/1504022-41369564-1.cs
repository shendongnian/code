    public class GlobalObjClassName : INotifyPropertyChanged
    {
        //  ... etc. etc. etc. ...
        public static List<slowniki> SLO_PER_UCZ = new List<slowniki>();
        private int _selectedIDPoz = -1;
        public int SelectedIDPoz
        {
            get { return _selectedIDPoz; }
            set
            {
                if (value != _selectedIDPoz)
                {
                    _selectedIDPoz = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] String propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
