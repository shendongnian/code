    public sealed partial class MainPage : Page
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            App.Current.IsIdleChanged += onIsIdleChanged;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            App.Current.IsIdleChanged -= onIsIdleChanged;
        }
        private void onIsIdleChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"IsIdle: {App.Current.IsIdle}");
        }
    }
