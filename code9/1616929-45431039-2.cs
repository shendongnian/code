    class PersoanaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        [...]
    
        public Persoana Persoana 
        {
            get
            {
                return _persoana;
            }
            set
            {
                if(value == _persoana) return; // do not update if the objects are equal
                _persoana = value;
                OnPropertyChanged(nameof(Nume));
            }
        }
    }
