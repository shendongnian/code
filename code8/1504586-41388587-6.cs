    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var viewModel = new MainPageViewModel();
            BindingContext = viewModel;
            ...
            viewModel.NavigationRequested += (s,e) => Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(e.PageToNavigate));
        }       
        
        ...
    }
    async void lvMain_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var listView = sender as ListView;
        var viewModel = BindingContext as MainPageViewModel;
        viewModel?.ListViewItemSelectedCommand?.Invoke(e);
        listView.SelectedItem = null;
    }
