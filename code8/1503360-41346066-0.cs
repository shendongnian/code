    public class ItemPresupuesto : INotifyPropertyChanged
    {
        private decimal _cantidad;
        public decimal Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; NotifyPropertyChanged(); NotifyPropertyChanged(nameof(Total)); }
        }
        private decimal _prico = 1;
        public decimal Prico
        {
            get { return _prico; }
            set { _prico = value; NotifyPropertyChanged(); NotifyPropertyChanged(nameof(Total)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public decimal Total => _prico * _cantidad;
    }
