    public class PreviewItemClass : ObservableObject
    {
        private string _descr1;
        public string descr1
        {
            get
            {
                return _descr1;
            }
            set
            {
                _descr1= value;
                RaisePropertyChanged("descr1");
            }
        }
        private string _descr2;
        public string descr2
        {
            get { return _descr2; }
            set
            {
                _descr = value;
                RaisePropertyChanged("descr2");
            }
        }
    }
