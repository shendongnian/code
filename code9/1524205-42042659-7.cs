    public class MainViewModel : INotifyPropertyChanged
    {
        IMobileServiceTable<ProductTable> product = App.MobileService.GetTable<ProductTable>();
        public List<ProductTable> Products { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public async void Load()
        {
            Products = await product
                .Where(ProductTable => ProductTable.Price == 15)
                .ToListAsync();
            //Notify that the property has changed to alert to UI to update.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Products)));
        }
    }
