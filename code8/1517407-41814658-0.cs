    public class MainViewModel :  Notifier
    {
        public static getWells gw = new getWells();
        public static ObservableCollection<string> headers = gw.getHeaders();
        private WellListGroup _wlg = new WellListGroup {headers = headers, selected = null};
        public WellListGroup wlg 
        {
            get { return _wlg; }
            set { _wlg = value; OnPropertyChanged("wlg"); }
    }
