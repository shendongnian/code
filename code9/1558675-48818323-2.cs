    public class ItemsViewModel : ViewModelBase
    {
        public INavigationHandler NavigationHandler { private get; set; }
        // some VM code here where in some place i'm invoking
        RelayCommand<int> ItemSelectedCommand => 
            new RelayCommand<int>((itemID) => { NavigationHandler.NavigateToItemDetail(itemID); });
        public interface INavigationHandler
        {
            void NavigateToItemDetail(int itemID);
        }
    }
