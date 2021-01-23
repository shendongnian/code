    public class MainViewModel
    {
       <!-- Your stuff ->
       public ChildViewModel ChildViewModel
       {
          if(_childViewModel == null)
          { 
             _childViewModel = new ChildViewModel(ProductList)
          }
          return _childViewModel;         
       }
    }
