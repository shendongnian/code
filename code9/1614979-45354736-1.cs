    public class ProductGroup : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void onPropertyChanged(object sender, string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
                }
            }
            private decimal _priceSum;
            private int _count;
            public Product groupedProduct { get; set; }
            public int Count
            {
                get
                {
                    return _count;
                }
                set
                {
                    _count = value;
                    onPropertyChanged(this, "Count");
                }
            }
            public decimal Price { get; set; }
            public decimal PriceSum
            {
                get { return _priceSum; }
                set
                {
                    _priceSum = value;
                    onPropertyChanged(this, "PriceSum");
                }
            }
        }
