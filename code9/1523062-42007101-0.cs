    class ViewModel
    {
        public ViewModel()
        {
            Variables = new List<string> { "A_Variable", "B_Variable" };
            SelectedVar = "A_Variable"; //default selected value...
        }
        public IEnumerable<string> Variables { get; private set; }
        private string _SelectedVar;
        public string SelectedVar
        {
            get { return _SelectedVar; }
            set
            {
                if (_SelectedVar == value) return;
                _SelectedVar = value;
                OnPropertyChanged("SelectedVar");
            }
        }
        //...
    }
