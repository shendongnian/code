    public class SelectionViewModel : INotifyPropertyChanged
    {
        private string _selectionmode = null;
        
        public string Selectionmode
        {
            get { return _selectionmode; }
            set
            {
				if (_selectionmode == value)
                    return;
                _selectionmode = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsQuarterSelected));
                OnPropertyChanged(nameof(IsMonthSelected));
				OnPropertyChanged(nameof(IsWeekSelected));
            }
        }
        
        public bool IsQuarterSelected
        {
            get { return Selectionmode == "Quarter"; }
			set { Selectionmode = value ? "Quarter" : Selectionmode; }
        }
        
        public bool IsMonthSelected
        {
            get { return Selectionmode == "Month"; }
			set { Selectionmode = value ? "Month" : Selectionmode; }
        }
        
        public bool IsWeekSelected
        {
            get { return Selectionmode == "Week"; }
			set { Selectionmode = value ? "Week" : Selectionmode; }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
