    public abstract class DealerBase : INotifyPropertyChanged
    {
        public string Name { get; }
        
        protected decimal _Price;
        public decimal Price 
        { 
            get { return _Price; }
            set
            {
                if (Equals(_Price, value)) return;
                _Price = value;
                // next method will inform DataGridView about changes
                // and update value there too 
                RaisePropertyChanged();         
            }
        protected DealerBase(string name)
        {
            Name = name;
        }  
        public abstract void UpdatePrice();  
        // Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }  
    }
