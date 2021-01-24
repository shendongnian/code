    using System.ComponentModel;
    public class Module : INotifyPropertyChanged
    {
        private string _number;
        public string Number
        {
            get { return this._number; }
            set
            {
                if (_number == value) return;
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }
		
		private double _ch1;
        public double Ch1
        {
            get { return this._ch1; }
            set
            {
                if (_ch1 == value) return;
                _ch1 = value;
                OnPropertyChanged(nameof(Ch1));
            }
        }
		
		//other channels fits there
		
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string aNameOfProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aNameOfProperty));
        }
    }
	
