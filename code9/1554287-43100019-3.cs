    public class BoardCell : INotifyPropertyChanged
    {
        private string _sign;
        private bool _canSelect = true;
        public string Sign
        {
            get { return _sign; }
            set
            {
                _sign = value;
                if (value != null)
                    CanSelect = false;
                OnPropertyChanged();
            }
        }
        public bool CanSelect
        {
            get { return _canSelect; }
            set
            {
                _canSelect = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
<!---->
    public class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private ObservableCollection<BoardCell> _cells;
        public ObservableCollection<BoardCell> Cells
        {
            get
            {
                if (_cells == null)
                    _cells = new ObservableCollection<BoardCell>(Enumerable.Range(0, Rows*Columns).Select(i => new BoardCell()));
                return _cells;
            }
        } 
    }
