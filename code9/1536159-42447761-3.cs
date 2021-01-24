    public class ShopingCartViewModel : MvxViewModel
    {
        readonly ISharedShoppingCart _sharedShoppingChart;
    
        public ShopingCartViewModel(ISharedShoppingCart sharedShoppingChart)
        {
            _sharedShoppingChart = sharedShoppingChart;
        }
    
        public MvxObservableCollection<ItemInfo> ShoppingCartItems
        {
            get { return _sharedShoppingChart.ShoppingCartItems; }
            set { _sharedShoppingChart.ShoppingCartItems = value; }
        }
    }
    
    public class ItemInfoViewModel : MvxViewModel
    {
        readonly ISharedShoppingCart _sharedShoppingCart;
    
        public ItemInfoViewModel(ISharedShoppingCart sharedShoppingCart)
        {
            _sharedShoppingCart = sharedShoppingCart;
        }
    
        void RemoveItemFromCart(int id)
        {
            _sharedShoppingCart.ShoppingCartItems
                .Remove(_sharedShoppingCart.ShoppingCartItems.Single(x => x.Id == id));
        }
    }
