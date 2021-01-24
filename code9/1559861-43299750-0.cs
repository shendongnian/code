    public class MyViewModel : INotifyPropertyChanged
    {
        private DateTime _Documenti;
        public DateTime Documenti
        {
            get { return _Documenti; }
            set
            {
                if (_Documenti != value)
                {
                    _Documenti = value;
                    RaisePropertyChanged("Documenti");
                    RaisePropertyChanged("DatePart");
                    RaisePropertyChanged("TimePart");
                }
            }
        }
        public DateTime DatePart
        {
            get { return Documenti; }
            set
            {
                Documenti = new DateTime(value.Year, value.Month, value.Day, Documenti.Hour, Documenti.Minute, Documenti.Second);
            }
        }
        public DateTime TimePart
        {
            get { return Documenti; }
            set
            {
                Documenti = new DateTime(Documenti.Year, Documenti.Month, Documenti.Day, value.Hour, value.Minute, value.Second);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string prop)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(prop));
        }
    }
