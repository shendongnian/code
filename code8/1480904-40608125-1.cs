    public class ChildViewModel
    {
       private List<ProductInfo> _products;
    
       public DelegateCommand ClearCollection {get; set;}
    
       public ChildViewModel(List<ProductInfo> products)
       { 
          _products = products;
          ClearCollection = new DelegateCommand(OnClearCollection);
       }
    
       private void OnClearCollection()
       {
          _products.Clear();
       }
    }
