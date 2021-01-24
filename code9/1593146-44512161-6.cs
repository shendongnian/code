    public class StoreDb
    {
        public ObservableCollection<Product> GetProducts()
        {
            string StoreData = string.Empty;
            using(StreamReader sr = new StreamReader("store.xml"))
              {
                  StoreData = sr.ReadToEnd();
              }
            ObservableCollection<Product> products = new ObservableCollection<Product>(StoreData.ToClass<List<Product>());
            
            return products;
        }
    }
