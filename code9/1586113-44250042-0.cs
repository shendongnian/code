    public class BasketItem : INotifyPropertyChanged
    {
        private int quantity = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public int ItemQuantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                if (value != this.quantity)
                {
                    this.quantity = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
