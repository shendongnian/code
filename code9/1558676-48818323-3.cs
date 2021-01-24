    public class ItemsPage : ContentPage, ItemsViewModel.INavigationHandler
    {
        ItemsViewModel viewModel;
        public ItemsPage()
        {
            viewModel = Container.Default.Get<ItemsViewModel>();
            viewModel.NavigationHandler = this;
        }
        public async void NavigateToItemDetail(int itemID)
        {
            await Navigation.PushAsync(new ItemDetailPage(itemID));
        }
    }
