    class Invoice : INotifyPropertyChanged
    {
        private int _amount;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public int Amount 
        {
           get{return _amount;}
           set
           {
              _amount = value;
              PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Amount)))
           }
        }
    }
