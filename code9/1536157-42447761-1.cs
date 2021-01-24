    public interface ISharedShoppingCart
    {
        MvxObservableCollection<ItemInfo> ShoppingCartItems { get; set; }
    }
    
    public class SharedShoppingCart : MvxNotifyPropertyChanged, ISharedShoppingCart
    {
        MvxObservableCollection<ItemInfo> _shoppingCartItems;
        public MvxObservableCollection<ItemInfo> ShoppingCartItems
        {
            get { return _shoppingCartItems; }
            set { SetProperty(ref _shoppingCartItems, value); }
        }
    }
