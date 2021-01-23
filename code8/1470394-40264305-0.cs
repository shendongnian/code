    public class DOSAdminProductHrcyViewModel : INotifyPropertyChanged {
    
        private readonly IWebApiDataAdapter _webAPIDataAdapter;
    
        public DOSAdminProductHrcyViewModel() {
            this._webAPIDataAdapter = new DosAdminDataAdapter();
            ProductList = new ObservableCollection<Product>();
        }
    
        public ObservableCollection<Product> ProductList {get; set;}
    
        public async Task GetProductListAsync() {
            try {
                var result = await _webAPIDataAdapter.GetProductHierarchy();
                ProductList = new ObservableCollection<Product>(result);
                OnPropertyChanged("ProductList");    
            } catch (Exception ex) {
                throw (ex);
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
