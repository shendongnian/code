    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var viewModel = new MainPageViewModel();
            BindingContext = viewModel;
            ...
            viewModel.NavigationRequested += (s,e) => Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(e));
        }       
        
        ...
        void lvMain_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;
            listView.SelectedItem = null;
            var viewModel = (MainPageViewModel)BindingContext;
            viewModel.ListViewItemSelectedCommand?.Invoke(e);
        }
    }
