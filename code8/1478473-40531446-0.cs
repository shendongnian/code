    public abstract class DealerViewModelBase : INotifyPropertyChanged
    {
        public string Name { get; }
        
        protected decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set
            {
                if(Equals(_Price, value)) return;
                _Price = value;
                RaisePropertyChanged();
            }
        }
        protected DealerViewModelBase(string name)
        {
            Name = name;
        }
        // This will be implemented in derived classes
        public abstract void UpdatePrice() 
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }        
    }
