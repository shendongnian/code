    public class MainModel:INotifyPropertyChanged    
    {   
            event PropertyChangedEventHandler PropertyChanged;  
            ObservableCollection<Product> _ProductsList = null;  
            ObservableCollection<Crystal> Crystals = null;  
            Product _SelectedProduct = null;
    
        public ObservableCollection<Product> ProductsList   
        {
            get
            {
                return _ProductsList;
            } 
            set
            {
                _ProductsList=value;
                PropertyChanged?.Invoke(this,new System.ComponentModel.PropertyChangedEventArgs("ProductsList")); 
            }
        }  
    
        public ObservableCollection<Crystal> Crystals    
        {
            get
            {
                return _Crystals;
            } 
            set
            {
                _Crystals=value;
                PropertyChanged?.Invoke(this,new System.ComponentModel.PropertyChangedEventArgs("Crystals")); 
            }
        } 
    
        public Product SelectedProduct
        {
            get
            {
                return _SelectedProduct;
            }
            set
            {
                _SelectedProduct = value;
                PropertyChanged?.Invoke(this,new System.ComponentModel.PropertyChangedEventArgs("SelectedProduct")); 
                ResetCrystals();
            }
        } 
        private void ResetCrystals()
        {
             Crystals=.....
        }
    }
