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
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string aNameOfProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aNameOfProperty));
        }
    }
