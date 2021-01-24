    //All NavigationPage in your app should use this class!
    public class CustomNavigationPage : NavigationPage
    {
        public BaseNavigationPage(Page page) : base(page)
        {
            this.Pushed += OnPushed;
            this.Popped += OnPopped;
        }
        void OnPushed(object sender, NavigationEventArgs e)
        {
            PageService.CurrentPage = e.Page;
        }
        void OnPopped(object sender, NavigationEventArgs e)
        {
            PageService.CurrentPage = ((App)App.Current).FindCurrentPage();
        }
    }
